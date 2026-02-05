using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wetter.Services;

namespace wetter.ViewModels
{
    internal class WetterViewModel
    {
        private ILocationService? _locationService;
        public WetterViewModel() 
        {
            _locationService = LocationServise.GetInstance();
            _locationService.UpdateLocationAsync();
        }
    }
}
