using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wetter.Models.ListModels;
using wetter.Models.LocationsModel;
using wetter.Models.WeatherCode;
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
        public event EventHandler? CanExecuteChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands
        private RelayCommand? _refreshCommand;

        public RelayCommand? RefreshCommand
        {
            get
            {
                return _refreshCommand
                  ?? (_refreshCommand = new RelayCommand(
                    async () =>
                    {
                        await GetCurrentWetherAsync();
                    }));
            }
        }
        #endregion

        #region Initialise Service

        private ILocationService _locationService;
        private IWeatherForecastService _weatherForecastService;
        private IWeatherCodeService _weatherCodeService;

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

        private Uri _fotoPath;
        public Uri FotoPath
        {
            get => _fotoPath;
            set
            {
                if (_fotoPath != value)
                {
                    _fotoPath = value;
                }
                OnPropertyChanged(nameof(FotoPath));
            }
        }

        private string _wetterBeschreibung = string.Empty;
        public string WetterBeschreibung
        {
            get => _wetterBeschreibung;
            set
            {
                if(_wetterBeschreibung != value)
                {
                    _wetterBeschreibung=value;
                }
                OnPropertyChanged(nameof(WetterBeschreibung));
            }
        }

        private string _gefuehlteTemperature = string.Empty;
        public string GefuehlteTemperature
        {
            get => _gefuehlteTemperature;
            set
            {
                if(_gefuehlteTemperature != value)
                {
                    _gefuehlteTemperature = value;
                }
                OnPropertyChanged(nameof(GefuehlteTemperature));
            }
        }

        private string _windGesschwindigkeit = string.Empty;
        public string WindGesschwindigkeit
        {
            get => _windGesschwindigkeit;
            set
            {
                if (_windGesschwindigkeit != value)
                {
                    _windGesschwindigkeit = value;
                }
                OnPropertyChanged(nameof(WindGesschwindigkeit));
            }
        }

        private double _windRichtung;
        public double WindRichtung
        {
            get => _windRichtung;
            set
            {
                if (_windRichtung != value)
                {
                    _windRichtung = value;
                }
                OnPropertyChanged(nameof(WindRichtung));
            }
        }

        private string _regen = string.Empty;
        public string Regen
        {
            get => _regen;
            set
            {
                if (_regen != value)
                {
                    _regen = value;
                }
                OnPropertyChanged(nameof(Regen));
            }
        }

        private string _schnee = string.Empty;
        public string Schnee
        {
            get => _schnee;
            set
            {
                if (_schnee != value)
                {
                    _schnee = value;
                }
                OnPropertyChanged(nameof(Schnee));
            }
        }

        private string _niederschlag = string.Empty;
        public string Niederschlag
        {
            get => _niederschlag;
            set
            {
                if(_niederschlag != value)
                {
                    _niederschlag= value;
                }
                OnPropertyChanged(nameof(Niederschlag));
            }
        }

        private string _feuchte = string.Empty;
        public string Feuchte
        {
            get => _feuchte;
            set
            {
                if(_feuchte != value)
                {
                    _feuchte= value;
                }
                OnPropertyChanged(nameof(Feuchte));
            }
        }

        private DateOnly _datum;
        public DateOnly Datum
        {
            get =>  _datum;
            set
            {
                if(_datum != value)
                {
                     _datum = value;
                }
                OnPropertyChanged(nameof(Datum));
            }
        }

        private TimeOnly _zeit;
        public TimeOnly Zeit
        {
            get => _zeit;
            set
            {
                if (_zeit != value)
                {
                    _zeit = value;
                }
                OnPropertyChanged(nameof(Zeit));
            }
        }

        private Dictionary<int, WeatherCodeModel> _weatherCodes;
        public ObservableCollection<SmallWeatherModel> SmallWeatherModelsCollection;
        #endregion

        
        public WetterViewModel() 
        {
            _locationService = LocationServise.GetInstance();
            _weatherForecastService = WeatherForecastService.GetInstance();
            _weatherCodeService = WeatherCodeService.GetInstanse();

            _weatherCodes = new Dictionary<int, WeatherCodeModel>();
            SmallWeatherModelsCollection = new ObservableCollection<SmallWeatherModel>();
        }

        public async Task Initialize()
        {
            _weatherCodes = await _weatherCodeService.GetWeatherCode();

            await GetKoordinaten();
            await GetLocationInfoAsync(_locationService.Latitude, _locationService.Longitude);
            await GetCurrentWetherAsync();
            await GetHourlyWetherAsync();


        }
        private async Task GetKoordinaten() => await _locationService.UpdateLocationAsync();

        private async Task GetLocationInfoAsync(double latitude, double longitude)
        {
           var location =  await _locationService.GetLocationInfoAsync(latitude: latitude, longitude: longitude);

            if(location is not null)
            {
                Land = location.Address.Country ?? string.Empty;

                Stadt = location.Address.Town ?? string.Empty;
            }
        }

        private async Task GetCurrentWetherAsync()
        {
            await GetKoordinaten();

            var currentWeather = await _weatherForecastService.GetCurrentWeatherAsync(days: 1, latitude:_locationService.Latitude, longitude: _locationService.Longitude, timezone:"Europe/Berlin");
            if(currentWeather.CurrentWeather is not null)
            {
                ActuelesTemeperatur = $"{currentWeather.CurrentWeather.Temperature} {currentWeather.CurrentUnits.Temperature}";
                WindGesschwindigkeit = $"{currentWeather.CurrentWeather.WindSpeed} {currentWeather.CurrentUnits.WindSpeed}";
                Feuchte = $"{currentWeather.CurrentWeather.RelativeHumidity} {currentWeather.CurrentUnits.RelativeHumidity}";
            }

            if(_weatherCodes is not null && currentWeather.CurrentWeather is not null)
            {
                int isDay = currentWeather.CurrentWeather.IsDay;
                int code = currentWeather.CurrentWeather.WeatherCode;
                
                if(isDay == 1)
                {
                    FotoPath = new Uri(_weatherCodes[code].Day.Image);
                    WetterBeschreibung = _weatherCodes[code].Day.Description;
                }
                else
                {
                    FotoPath = new Uri(_weatherCodes[code].Night.Image);
                    WetterBeschreibung = _weatherCodes[code].Night.Description;
                }
            }
        }

        private async Task GetHourlyWetherAsync()
        {
            await GetKoordinaten();

            var hourlyWeather = await _weatherForecastService.GetHourlyWeatherAsync(days: 1, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");
            var dailyWeather = await _weatherForecastService.GetDailyWeatherAsync(days: 1, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");

            if (hourlyWeather.HourlyWeather is null || dailyWeather.DailyWeather is null)
                return;

            TimeOnly sonneAufgang = TimeOnly.FromDateTime(dailyWeather.DailyWeather.Sunrise.FirstOrDefault());
            TimeOnly sonneUntergang = TimeOnly.FromDateTime(dailyWeather.DailyWeather.Sunset.FirstOrDefault());

            for (int i = 0; i < hourlyWeather.HourlyWeather.Temperature?.Count; i++)
            {
                TimeOnly actTime = TimeOnly.FromDateTime(hourlyWeather.HourlyWeather.Time[i]);
                int code = hourlyWeather.HourlyWeather.WeatherCode[i];

                SmallWeatherModelsCollection.Add(new SmallWeatherModel
                {
                    Zeit = TimeOnly.FromDateTime(hourlyWeather.HourlyWeather.Time[i]),

                    WeatherTemperatur = hourlyWeather.HourlyWeather.Temperature[i],

                    WeatherCodeImagePath = (actTime > sonneUntergang && actTime < sonneUntergang) ? _weatherCodes[code].Day.Image : _weatherCodes[code].Night.Image
                });
            }

        }


    }
}
