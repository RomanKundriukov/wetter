using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wetter.Models.LocationsModel;
using wetter.Models.WetterModels;
using Windows.Devices.Geolocation;

namespace wetter.Services.LocationService
{
    /// <summary>
    /// Provides functionality for retrieving and updating geographic location information, including latitude,
    /// longitude, and detailed address data using external geocoding services.
    /// </summary>
    /// <remarks>This class implements a singleton pattern to ensure a single instance throughout the
    /// application's lifetime. It offers asynchronous methods for updating device location and obtaining address
    /// details, relying on external services and device permissions. Network connectivity and user permissions may
    /// affect the availability and accuracy of location data.</remarks>
    internal class LocationServise : ILocationService
    {
        private readonly HttpClient _httpClient;
        /// <summary>
        /// Gets the latitude component of the geographic coordinate.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude coordinate in degrees.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Represents the singleton instance of the LocationServise class.
        /// </summary>
        /// <remarks>This field is used to implement the singleton pattern, ensuring that only one
        /// instance of LocationServise exists throughout the application's lifetime.</remarks>
        private static readonly LocationServise? _instance = new LocationServise(new HttpClient());

        /// <summary>
        /// Initializes a new instance of the LocationServise class.
        /// </summary>
        private LocationServise(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://nominatim.openstreetmap.org/reverse");
        }
        /// <summary>
        /// Gets the singleton instance of the LocationServise class.
        /// </summary>
        /// <remarks>Use this method to access the global LocationServise instance. This method always
        /// returns the same instance.</remarks>
        /// <returns>The single, shared instance of the LocationServise class.</returns>
        internal static LocationServise GetInstance() => _instance!;

        /// <summary>
        /// Asynchronously updates the current latitude and longitude properties with the device's latest geographic
        /// location.
        /// </summary>
        /// <remarks>If the location cannot be retrieved, a dialog is displayed to inform the user of the
        /// error. The method requires location permissions to be granted by the user and may prompt for them if not
        /// already provided.</remarks>
        /// <param name="ct">A cancellation token that can be used to cancel the location update operation.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        public async Task UpdateLocationAsync()
        {
            try
            {
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1 };
                Geoposition position = await geolocator.GetGeopositionAsync();

                Latitude = position.Coordinate.Point.Position.Latitude;
                Longitude = position.Coordinate.Point.Position.Longitude;

            }
            catch (Exception ex)
            {

                ContentDialog noWifiDialog = new ContentDialog
                {
                    Title = "Location",
                    Content = ex,
                    CloseButtonText = "OK"
                };

                ContentDialogResult result = await noWifiDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Retrieves detailed location information for the specified geographic coordinates.
        /// </summary>
        /// <remarks>The location information is retrieved using an external geocoding service. The
        /// response includes address details and is localized in German. The method performs an HTTP request and may be
        /// subject to network latency or failures.</remarks>
        /// <param name="latitude">The latitude component of the geographic coordinate, in decimal degrees. Must be within the valid range of
        /// -90 to 90.</param>
        /// <param name="longitude">The longitude component of the geographic coordinate, in decimal degrees. Must be within the valid range of
        /// -180 to 180.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="LocationModel"/>
        /// with location details for the specified coordinates. If no location is found, an empty <see
        /// cref="LocationModel"/> is returned.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving location information.</exception>
        public async Task<LocationModel> GetLocationInfo(double latitude, double longitude)
        {
            try
            {
                var url =
                    $"?format=jsonv2" +
                    $"&lat={latitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&lon={longitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&addressdetails=1" +
                    $"&accept-language=de";

                var req = new HttpRequestMessage(HttpMethod.Get, url);
                req.Headers.UserAgent.ParseAdd("wetter/1.0");
                req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(req);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadFromJsonAsync<LocationModel>()
                        .ConfigureAwait(false);
                    return model ?? new LocationModel();
                }
                else
                {
                    throw new InvalidOperationException(response?.RequestMessage?.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
