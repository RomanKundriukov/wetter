using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace wetter.Services
{
    internal class LocationServise
    {
        private static LocationServise? _instance;
        private LocationServise() { }
        internal static LocationServise GetInstance()
        {
            if (_instance is null)
            {
                _instance = new LocationServise();
            }
            return _instance;
        }

        internal double Latitude { get; set; }
        internal double Longitude { get; set; }

        internal async Task GetLocation()
        {
            Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 50 };
            Geoposition position =  await geolocator.GetGeopositionAsync();

            Latitude = position.Coordinate.Point.Position.Latitude;
            Longitude = position.Coordinate.Point.Position.Longitude;
        }
    }
}
