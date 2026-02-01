using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wetter.Services
{
    internal interface ILocationService
    {
        double Latitude { get; }
        double Longitude { get; }
        Task UpdateLocationAsync(CancellationToken ct = default);
    }
}
