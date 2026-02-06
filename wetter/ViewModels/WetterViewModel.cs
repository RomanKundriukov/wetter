using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using wetter.Models.LocationsModel;
using wetter.Models.WetterModels;
using wetter.Services;
using wetter.Services.FileReader;
using wetter.Services.LocationService;
using wetter.Services.WeatherCode;

namespace wetter.ViewModels
{
    internal class WetterViewModel : INotifyPropertyChanged
    {
        #region Notification Property Changed

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Initialise Service

        private ILocationService _locationService;
        private WeatherForecastService _weatherForecastService;
        private WeatherCodeService _weatherCode;

        #endregion

        #region Variablen

        private string _land = string.Empty;
        public string Land
        {
            get => _land;
            set
            {
                if (_land != value)
                {
                    _land = value;
                }
                
                OnPropertyChanged(nameof(Land));
            }
        }

        private string _bundesland = string.Empty;
        public string Bundesland
        {
            get => _bundesland;
            set
            {
                if (_bundesland != value)
                {
                    _bundesland = value;
                }
                
                OnPropertyChanged(nameof(Bundesland));
            }
        }

        private string _stadt = string.Empty;
        public string Stadt
        {
            get => _stadt;
            set
            {
                if (_stadt != value)
                {
                    _stadt = value;
                }
                OnPropertyChanged(nameof(Stadt));
            }
        }

        private string _vorort = string.Empty;
        public string Vorort
        {
            get => _vorort;
            set
            {
                if(_vorort != value)
                {
                    _vorort = value;
                }
                OnPropertyChanged(nameof(Vorort));
            }
        }

        private string _strasse = string.Empty;
        public string Strasse
        {
            get => _strasse;
            set
            {
                if (_strasse != value)
                {
                    _strasse = value;
                }
                OnPropertyChanged(nameof(Strasse));
            }
        }

        private string _hausNummer = string.Empty;
        public string HausNummer
        {
            get => _hausNummer;
            set
            {
                if (_hausNummer != value)
                {
                    _hausNummer = value;
                }
                OnPropertyChanged(nameof(HausNummer));
            }
        }
       
        private string _actuelesTemeperatur = string.Empty;
        public string ActuelesTemeperatur
        {
            get => _actuelesTemeperatur;
            set
            {
                if(_actuelesTemeperatur != value)
                {
                    _actuelesTemeperatur=value;
                }
                OnPropertyChanged(nameof(ActuelesTemeperatur));
            }
        }

        #endregion


        public WetterViewModel() 
        {
            _locationService = LocationServise.GetInstance();
            _weatherForecastService = WeatherForecastService.GetInstance();
            _weatherCode = WeatherCodeService.GetInstanse();
        }

        public async Task Initialize()
        {
            //await GetKoordinaten();
            //await GetLocationInfoAsync(_locationService.Latitude, _locationService.Longitude);
            //await GetCurrentWetherAsync();

            await GetWeatherCode();
        }
        private async Task GetKoordinaten() => await _locationService.UpdateLocationAsync();

        private async Task GetLocationInfoAsync(double latitude, double longitude)
        {
           var location =  await _locationService.GetLocationInfoAsync(latitude: latitude, longitude: longitude);

            if(location is not null)
            {
                Land = location.Address.Country ?? string.Empty;

                Bundesland = location.Address.State ?? string.Empty;

                Stadt = location.Address.Town ?? string.Empty;

                Strasse = location.Address.Road ?? string.Empty;

                HausNummer = location.Address.HouseNumber ?? string.Empty;

                Vorort = location.Address.Village ?? string.Empty;
            }
            
        }

        private async Task GetCurrentWetherAsync()
        {
            var currentWeather = await _weatherForecastService.GetCurrentWeatherAsync(days: 1, latitude:_locationService.Latitude, longitude: _locationService.Longitude, timezone:"Europe/Berlin");

            if(currentWeather.CurrentWeather is not null)
            {
                ActuelesTemeperatur = $"{currentWeather.CurrentWeather.Temperature} {currentWeather.CurrentUnits.Temperature}"; 
            }
        }

        private async Task GetWeatherCode()
        {
           await _weatherCode.GetWeatherCode();
        }
        //private async Task InitializeAsync()
        //{
        //    await _locationService.UpdateLocationAsync();

        //    // Jetzt sind Latitude/Longitude gesetzt
        //    await _weatherForecastService.GetHourlyWeather(
        //        7,
        //        _locationService.Latitude,
        //        _locationService.Longitude,
        //        "Europe/Berlin");

        //    await _locationService.GetLocationInfo(_locationService.Latitude, _locationService.Longitude);
        //}
    }
}
