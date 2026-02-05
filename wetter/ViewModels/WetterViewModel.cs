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
        WeatherForecastService _weatherForecastService;
        public WetterViewModel() 
        {
            _locationService = LocationServise.GetInstance();
            _weatherForecastService = WeatherForecastService.GetInstance();


            _ = InitializeAsync(); // fire-and-forget, aber kontrolliert
            //Task.WaitAny(_locationService.UpdateLocationAsync());

            //WeatherForecastService weatherForecastService = WeatherForecastService.GetInstance();

            //weatherForecastService.GetCurrentWeather(1, _locationService.Latitude, _locationService.Longitude, "Europe/Berlin");
        }

        private async Task InitializeAsync()
        {
            await _locationService.UpdateLocationAsync();

            // Jetzt sind Latitude/Longitude gesetzt
            await _weatherForecastService.GetCurrentWeather(
                1,
                _locationService.Latitude,
                _locationService.Longitude,
                "Europe/Berlin");
        }
    }
}
