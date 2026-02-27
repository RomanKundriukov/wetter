using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using wetter.Models.ListModels;
using wetter.Models.WeatherCode;
using wetter.Services;
using wetter.Services.LocationService;
using wetter.Services.WeatherCode;

namespace wetter.ViewModels
{
    /// <summary>
    /// Represents the view model for weather data management, providing properties and methods to retrieve and display
    /// weather information based on user location and preferences.
    /// </summary>
    /// <remarks>This class implements the INotifyPropertyChanged interface to support data binding in the
    /// user interface. It manages weather-related properties and commands, and initializes services for location and
    /// weather data retrieval. The view model facilitates the display of current and forecasted weather information,
    /// enabling responsive updates to the UI as data changes.</remarks>
    internal class WetterViewModel : INotifyPropertyChanged
    {
        #region Notification Property Changed

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands
        //private RelayCommand? _toggledCommand;

        //public RelayCommand? ToggledCommand
        //{
        //    get
        //    {
        //        return _toggledCommand
        //          ?? (_toggledCommand = new RelayCommand(
        //            async () =>
        //            {
        //                //if(ToggleSwitch.IsOnProperty == 3)
        //                //    await GetTaeglicWetherAsync(3);
        //                //else
        //                    await GetTaeglicWetherAsync(7);
        //            }));
        //    }
        //}
        #endregion

        #region Initialise Service

        private ILocationService _locationService;
        private IWeatherForecastService _weatherForecastService;
        private IWeatherCodeService _weatherCodeService;

        #endregion

        #region Variablen

        private Axis[] _xAxes { get; set; } = new Axis[0];
        public Axis[] XAxes 
        {
            get => _xAxes;
            set
            {
                if(_xAxes != value)
                {
                    _xAxes = value;
                    OnPropertyChanged(nameof(XAxes));

                }
            }
        }
        private ISeries[] _uvIndex { get; set; } = new ISeries[0];
        public ISeries[] UVIndex
        {
            get => _uvIndex;
            set
            {
                if(_uvIndex != value)
                {
                    _uvIndex = value;
                    OnPropertyChanged(nameof(UVIndex));
                }
            }
        }

        private ISeries[] _schneeIndex { get; set; } = new ISeries[0];
        public ISeries[] SchneeIndex
        {
            get => _schneeIndex;
            set
            {
                if (_schneeIndex != value)
                {
                    _schneeIndex = value;
                    OnPropertyChanged(nameof(SchneeIndex));
                }
            }
        }

        private ISeries[] _regenIndex { get; set; } = new ISeries[0];
        public ISeries[] RegenIndex
        {
            get => _regenIndex;
            set
            {
                if (_regenIndex != value)
                {
                    _regenIndex = value;
                    OnPropertyChanged(nameof(RegenIndex));
                }
            }
        }

        private bool _is7Days;
        public bool Is7Days
        {
            get => _is7Days;
            set
            {
                if (_is7Days == value) return;
                _is7Days = value;
                OnPropertyChanged(nameof(Is7Days));

                int days = _is7Days ? 7 : 3;
                _ = GetTaeglicWetherAsync(days); // async starten
            }
        }

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

        private string _plz = string.Empty;
        public string PLZ
        {
            get => _plz;
            set
            {
                if (_plz != value)
                {
                    _plz = value;
                }
                OnPropertyChanged(nameof(PLZ));
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

        private Uri? _fotoPath { get; set; }
        public Uri? FotoPath
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
        public ObservableCollection<SmallWeatherModel> TaeglichWeatherModelsCollection;

        #endregion

        /// <summary>
        /// Initializes a new instance of the WetterViewModel class, setting up the required services and collections
        /// for weather data management.
        /// </summary>
        /// <remarks>This constructor creates singleton instances of the location, weather forecast, and
        /// weather code services. It also initializes observable collections for storing weather models, which are
        /// intended for data binding in the user interface.</remarks>
        public WetterViewModel() 
        {
            ///initialisiere die Services
            _locationService = LocationServise.GetInstance();
            _weatherForecastService = WeatherForecastService.GetInstance();
            _weatherCodeService = WeatherCodeService.GetInstanse();

            /// Initialisiere die Collections
            _weatherCodes = new Dictionary<int, WeatherCodeModel>();
            SmallWeatherModelsCollection = new ObservableCollection<SmallWeatherModel>();
            TaeglichWeatherModelsCollection = new ObservableCollection<SmallWeatherModel>();
        }

        /// <summary>
        /// Initializes the application asynchronously by retrieving weather codes, location information, and weather
        /// data.
        /// </summary>
        /// <remarks>This method performs multiple asynchronous operations to gather necessary data for
        /// the application, including fetching weather codes and current weather information based on the user's
        /// location.</remarks>
        /// <returns>This method does not return a value.</returns>
        public async Task InitializeAsync()
        {
            _weatherCodes = await _weatherCodeService.GetWeatherCode();

            await GetKoordinaten();
            await GetLocationInfoAsync(_locationService.Latitude, _locationService.Longitude);
            await GetCurrentWetherAsync();
            await GetHourlyWetherAsync();
            await GetTaeglicWetherAsync();
            await SetDiagramms();


        }

        /// <summary>
        /// Asynchronously updates the current location coordinates using the location service.
        /// </summary>
        /// <remarks>This method performs an asynchronous operation to refresh the location data. Ensure
        /// that the location service is properly initialized before calling this method.</remarks>
        /// <returns></returns>
        private async Task GetKoordinaten() => await _locationService.UpdateLocationAsync();

        /// <summary>
        /// Asynchronously retrieves address information for the specified geographic coordinates and updates related
        /// properties with the results.
        /// </summary>
        /// <remarks>If address information is successfully retrieved, the properties Land, Stadt, PLZ,
        /// Vorort, Strasse, and HausNummer are updated with the corresponding details. If no information is found,
        /// these properties are set to empty strings.</remarks>
        /// <param name="latitude">The latitude component of the location to query. Must be a valid coordinate value.</param>
        /// <param name="longitude">The longitude component of the location to query. Must be a valid coordinate value.</param>
        /// <returns>A task that represents the asynchronous operation. The method does not return a value.</returns>
        private async Task GetLocationInfoAsync(double latitude, double longitude)
        {
           var location =  await _locationService.GetLocationInfoAsync(latitude: latitude, longitude: longitude);

            if(location is not null)
            {
                Land = location.Address.Country ?? string.Empty;
                Stadt = location.Address.Town ?? string.Empty;
                PLZ = location.Address.Postcode ?? string.Empty;
                Vorort = location.Address.Village ?? string.Empty;
                Strasse = location.Address.Road ?? string.Empty;
                HausNummer = location.Address.HouseNumber ?? string.Empty;
            }
        }

        /// <summary>
        /// Asynchronously retrieves the current weather information for the specified location and updates the relevant
        /// properties with the retrieved data.
        /// </summary>
        /// <remarks>This method fetches the current weather data using the provided latitude and
        /// longitude. It updates properties such as temperature, wind speed, humidity, and weather description based on
        /// whether it is day or night. Ensure that the location service is properly initialized before calling this
        /// method.</remarks>
        /// <returns></returns>
        private async Task GetCurrentWetherAsync()
        {
            var currentWeather = await _weatherForecastService.GetCurrentWeatherAsync(days: 1, latitude:_locationService.Latitude, longitude: _locationService.Longitude, timezone:"Europe/Berlin");
            if(currentWeather.CurrentWeather is not null)
            {
                ActuelesTemeperatur = $"{currentWeather.CurrentWeather.Temperature} {currentWeather.CurrentUnits.Temperature}";
                WindGesschwindigkeit = $"{currentWeather.CurrentWeather.WindSpeed} {currentWeather.CurrentUnits.WindSpeed}";
                Feuchte = $"{currentWeather.CurrentWeather.RelativeHumidity} {currentWeather.CurrentUnits.RelativeHumidity}";
                WindRichtung = currentWeather.CurrentWeather.WindDirection;
            }

            if(_weatherCodes is not null && currentWeather.CurrentWeather is not null)
            {
                int isDay = (int)currentWeather.CurrentWeather.IsDay;
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

        /// <summary>
        /// Asynchronously retrieves hourly and daily weather data for the current location and updates the collection
        /// of small weather models with temperature and weather code information.
        /// </summary>
        /// <remarks>This method fetches weather data for one day using the configured latitude,
        /// longitude, and timezone. It ensures that both hourly and daily weather data, including sunrise and sunset
        /// times, are available before processing. The method populates the collection with weather models, selecting
        /// the appropriate weather code image based on the time of day.</remarks>
        /// <returns>A task that represents the asynchronous operation. The task completes when the weather data has been
        /// retrieved and the collection has been updated.</returns>
        private async Task GetHourlyWetherAsync()
        {

            var hourlyWeather = await _weatherForecastService.GetHourlyWeatherAsync(days: 1, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");
            var dailyWeather = await _weatherForecastService.GetDailyWeatherAsync(days: 1, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");

            if (hourlyWeather.HourlyWeather is null || dailyWeather.DailyWeather is null)
                return;
            if (dailyWeather.DailyWeather.Sunrise is null || dailyWeather.DailyWeather.Sunset is null)
                return;
            
            TimeOnly sonneAufgang = TimeOnly.FromDateTime(dailyWeather.DailyWeather.Sunrise.FirstOrDefault());
            TimeOnly sonneUntergang = TimeOnly.FromDateTime(dailyWeather.DailyWeather.Sunset.FirstOrDefault());

            for (int i = 0; i < hourlyWeather.HourlyWeather.Temperature?.Count; i++)
            {
                if(hourlyWeather.HourlyWeather is null)
                    return;

                TimeOnly actTime = TimeOnly.FromDateTime(hourlyWeather.HourlyWeather.Time[i]);
                if(hourlyWeather.HourlyWeather.WeatherCode is null)
                    return;

                int code = hourlyWeather.HourlyWeather.WeatherCode[i];

                SmallWeatherModelsCollection.Add(new SmallWeatherModel
                {
                    Zeit = TimeOnly.FromDateTime(hourlyWeather.HourlyWeather.Time[i]),

                    WeatherTemperatur = hourlyWeather.HourlyWeather.Temperature[i],

                    WeatherCodeImagePath = (actTime > sonneUntergang && actTime < sonneUntergang) ? _weatherCodes[code].Day.Image : _weatherCodes[code].Night.Image
                });
            }

        }

        /// <summary>
        /// Asynchronously retrieves daily weather data for a specified number of days and populates the collection with
        /// weather models.
        /// </summary>
        /// <remarks>This method clears the existing weather models collection before fetching new data.
        /// It requires valid latitude and longitude values from the location service. The method does not execute if
        /// sunrise or sunset data is unavailable.</remarks>
        /// <param name="days">The number of days for which to retrieve the weather data. Defaults to 3 days if not specified.</param>
        /// <returns></returns>
        private async Task GetTaeglicWetherAsync(int days = 3)
        {
            TaeglichWeatherModelsCollection.Clear();

            //var dailyWeather = await _weatherForecastService.GetHourlyWeatherAsync(days: days, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");
            var dailyWeather = await _weatherForecastService.GetDailyWeatherAsync(days: days, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");

            if (dailyWeather.DailyWeather.Sunrise is null || dailyWeather.DailyWeather.Sunset is null)
                return;

            TimeOnly sonneAufgang = TimeOnly.FromDateTime(dailyWeather.DailyWeather.Sunrise.FirstOrDefault());
            TimeOnly sonneUntergang = TimeOnly.FromDateTime(dailyWeather.DailyWeather.Sunset.FirstOrDefault());

            for (int i = 0; i < dailyWeather.DailyWeather.Time?.Count; i++)
            {
                if (dailyWeather.DailyWeather is null)
                    return;

                DateTime actDate = DateTime.Now;
                TimeOnly actTime = TimeOnly.FromDateTime(actDate);

                int code = dailyWeather.DailyWeather.WeatherCode[i];

                TaeglichWeatherModelsCollection.Add(new SmallWeatherModel
                {

                    WeatherCodeImagePath = (actTime > sonneUntergang && actTime < sonneUntergang) ? _weatherCodes[code].Day.Image : _weatherCodes[code].Night.Image,
                    MaxWeatherTemperatur = $"{dailyWeather.DailyWeather.TemperatureMax[i]} / {dailyWeather.DailyUnits.TemperatureMax}",
                    MinWeatherTemperatur = $"{dailyWeather.DailyWeather.TemperatureMin[i]} / {dailyWeather.DailyUnits.TemperatureMin}",
                    Datumg = dailyWeather.DailyWeather.Time[i].Day,
                    Monat = dailyWeather.DailyWeather.Time[i].ToString("MMMM"),
                    Tag = dailyWeather.DailyWeather.Time[i].ToString("dddd")
                });
            }

        }

        /// <summary>
        /// Asynchronously updates diagram series for hourly weather data, including UV index, snowfall, and
        /// precipitation, based on the current location.
        /// </summary>
        /// <remarks>This method retrieves hourly weather data for the current location and updates the
        /// corresponding diagram series. The latitude and longitude must be set in the location service prior to
        /// calling this method. If hourly weather data is unavailable, no updates are performed.</remarks>
        /// <returns></returns>
        private async Task SetDiagramms()
        {

            //var dailyWeather = await _weatherForecastService.GetHourlyWeatherAsync(days: days, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");
            var hourlyWeather = await _weatherForecastService.GetHourlyWeatherAsync(days: 1, latitude: _locationService.Latitude, longitude: _locationService.Longitude, timezone: "Europe/Berlin");

            if (hourlyWeather.HourlyWeather is null)
                return;

          
            for (int i = 0; i < hourlyWeather.HourlyWeather.Time?.Count; i++)
            {

                TimeSpan stunden = TimeSpan.FromHours(hourlyWeather.HourlyWeather.Time[i].Hour);
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = hourlyWeather.HourlyWeather.Time.Select(t => TimeOnly.FromDateTime(t).ToString("HH:mm")).ToArray()
                    }
                };

                UVIndex = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = hourlyWeather.HourlyWeather.UVIndex.Select(u => (double)u).ToArray()
                    }
                };

                SchneeIndex = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = hourlyWeather.HourlyWeather.Snowfall.Select(s => (double)s).ToArray()
                    }
                };

                RegenIndex = new ISeries[]
                {
                    new LineSeries<double>
                    {
                        Values = hourlyWeather.HourlyWeather.Precipitation.Select(p => (double)p).ToArray()
                    }
                };
            }
        }

    }
}
