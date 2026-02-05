using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wetter.Models.LocationsModel;

namespace wetter.Services.LocationService
{
    /// <summary>
    /// Provides access to the current geographic location, including latitude and longitude, and allows updating the
    /// location asynchronously.
    /// </summary>
    internal interface ILocationService
    {
        double Latitude { get; }
        double Longitude { get; }
        Task UpdateLocationAsync();
        Task<LocationModel> GetLocationInfo(double latitude, double longitude);
    }
}
