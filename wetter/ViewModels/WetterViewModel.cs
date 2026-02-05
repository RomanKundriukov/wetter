using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wetter.Services;
using wetter.Services.LocationService;

namespace wetter.ViewModels
{
    internal class WetterViewModel
    {
        private ILocationService? _locationService;
        WeatherForecastService _weatherForecastService;
        public WetterViewModel() 
        {
            _locationService = LocationServise.GetInstance();
            _weatherForecastService = WeatherForecastService.GetInstance();


            _ = InitializeAsync(); 
        }

        private async Task InitializeAsync()
        {
            await _locationService.UpdateLocationAsync();

            // Jetzt sind Latitude/Longitude gesetzt
            await _weatherForecastService.GetHourlyWeather(
                7,
                _locationService.Latitude,
                _locationService.Longitude,
                "Europe/Berlin");

            await _locationService.GetLocationInfo(_locationService.Latitude, _locationService.Longitude);
        }
    }
}
