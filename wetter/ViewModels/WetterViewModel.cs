using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using wetter.Models.LocationsModel;
using wetter.Services;
using wetter.Services.LocationService;

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
        WeatherForecastService _weatherForecastService;

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
       
        #endregion
        public WetterViewModel() 
        {
            _locationService = LocationServise.GetInstance();
            _weatherForecastService = WeatherForecastService.GetInstance();
        }

        public async Task Initialize()
        {
            await GetKoordinaten();
            await getLocationInfo(_locationService.Latitude, _locationService.Longitude);
        }
        private async Task GetKoordinaten() => await _locationService.UpdateLocationAsync();

        private async Task getLocationInfo(double latitude, double longitude)
        {
           var location =  await _locationService.GetLocationInfo(latitude: latitude, longitude: longitude);

            if(location is not null)
            {
                Land = location.Address.Country ?? string.Empty;

                Bundesland = location.Address.State ?? string.Empty;

                Stadt = $"{location.Address.Postcode ?? string.Empty}  {location.Address.Town ?? string.Empty}";

                Strasse = location.Address.Road ?? string.Empty;

                HausNummer = location.Address.HouseNumber ?? string.Empty;

                Vorort = location.Address.Village ?? string.Empty;
            }
            
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
