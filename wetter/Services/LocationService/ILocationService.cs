using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wetter.Services.LocationService
{
    /// <summary>
    /// Provides access to the current geographic location, including latitude and longitude, and allows updating the
    /// location asynchronously.
    /// </summary>
    internal interface ILocationService
    {
        Task UpdateLocationAsync();
    }
}
