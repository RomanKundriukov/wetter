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
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        private static readonly LocationServise? _instance = new LocationServise();
        private LocationServise() { }
        public static LocationServise GetInstance() => _instance!;
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
