using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace wetter.Services
{
    internal class LocationServise : ILocationService
    {
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
        private static readonly LocationServise? _instance = new LocationServise();
        /// <summary>
        /// Initializes a new instance of the LocationServise class.
        /// </summary>
        private LocationServise() { }
        /// <summary>
        /// Gets the singleton instance of the LocationServise class.
        /// </summary>
        /// <remarks>Use this method to access the global LocationServise instance. This method always
        /// returns the same instance.</remarks>
        /// <returns>The single, shared instance of the LocationServise class.</returns>
        public static LocationServise GetInstance() => _instance!;

        /// <summary>
        /// Asynchronously updates the current latitude and longitude properties with the device's latest geographic
        /// location.
        /// </summary>
        /// <remarks>If the location cannot be retrieved, a dialog is displayed to inform the user of the
        /// error. The method requires location permissions to be granted by the user and may prompt for them if not
        /// already provided.</remarks>
        /// <param name="ct">A cancellation token that can be used to cancel the location update operation.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        public async Task UpdateLocationAsync(CancellationToken ct = default)
        {
            try
            {
                Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 50 };
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

    }
}
