using ABI.System;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wetter.Models.WetterModels;
using Exception = System.Exception;
using TimeSpan = System.TimeSpan;
using Uri = System.Uri;

namespace wetter.Services
{
    /// <summary>
    /// Provides methods for retrieving current, daily, and hourly weather forecast data from the Open-Meteo API for a
    /// specified location and time zone.
    /// </summary>
    /// <remarks>This service is intended for internal use within the application and exposes a singleton
    /// instance for consistent access. All weather data retrieval methods are asynchronous and return strongly typed
    /// models representing the forecast information. The service is not thread-safe for modifications, but concurrent
    /// read operations are supported. Network errors or invalid input may result in exceptions; callers should handle
    /// these cases appropriately.</remarks>
    internal class WeatherForecastService : IWeatherForecasrService
    {
        /// <summary>
        /// Http Client
        /// </summary>
        private readonly HttpClient _httpClient;
       
        /// <summary>
        /// Represents the singleton instance of the WeatherForecastService.
        /// </summary>
        private static readonly WeatherForecastService? _instance = new WeatherForecastService(new HttpClient());

        /// <summary>
        /// Initializes a new instance of the WeatherForecastService class.
        /// </summary>
        /// <remarks>This constructor is private and is intended to restrict instantiation of the
        /// WeatherForecastService class to within the class itself. Use provided factory methods or static members to
        /// obtain an instance, if available.</remarks>
        private WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new System.Uri("https://api.open-meteo.com/v1/forecast");
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }
        /// <summary>
        /// Gets the singleton instance of the WeatherForecastService.
        /// </summary>
        /// <remarks>Use this method to access the WeatherForecastService throughout the application. The
        /// same instance is returned on each call.</remarks>
        /// <returns>The single, shared instance of the WeatherForecastService.</returns>
        internal static WeatherForecastService GetInstance() => _instance!;

        /// <summary>
        /// Retrieves the current weather data for the specified location and time zone over a given number of forecast
        /// days.
        /// </summary>
        /// <param name="days">The number of forecast days for which to retrieve weather data. Must be a positive integer.</param>
        /// <param name="latitude">The latitude of the location for which to retrieve weather data, in decimal degrees.</param>
        /// <param name="longitude">The longitude of the location for which to retrieve weather data, in decimal degrees.</param>
        /// <param name="timezone">The time zone identifier used to format the weather data. Cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see
        /// cref="CurrentWeatherModel"/> with the current weather information for the specified location and time zone.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while retrieving or processing the weather data.</exception>
        public async Task<CurrentWeatherModel> GetCurrentWeather(int days, double latitude, double longitude, string timezone)
        {
            try
            {
                string current =
                    "temperature_2m,relative_humidity_2m,rain,snowfall,weather_code,wind_speed_10m," +
                    "apparent_temperature,precipitation,wind_direction_10m,wind_gusts_10m";

                var url =
                    $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&current={Uri.EscapeDataString(current)}" +
                    $"&timezone={Uri.EscapeDataString(timezone)}" +
                    $"&forecast_days={days}" +
                    $"&wind_speed_unit=ms";

                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadFromJsonAsync<CurrentWeatherModel>()
                        .ConfigureAwait(false);
                    return model ?? new CurrentWeatherModel();
                }
                else
                {
                    throw new InvalidOperationException(response?.RequestMessage?.ToString());
                }
 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
 
        }

        /// <summary>
        /// Retrieves the dauly weather data for the specified location and time zone over a given number of forecast
        /// days.
        /// </summary>
        /// <param name="days"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="timezone"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see
        /// cref="DailyWeatherModel"/> with the current weather information for the specified location and time zone.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<DailyWeatherModel> GetDailyWeather(int days, double latitude, double longitude, string timezone) 
        {
            try
            {
                string daily =
                    "weather_code,temperature_2m_max,temperature_2m_min,precipitation_sum,precipitation_probability_max,rain_sum," +
                    "snowfall_sum,sunrise,sunset,wind_speed_10m_max,wind_gusts_10m_max";

                var url =
                    $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&daily={Uri.EscapeDataString(daily)}" +
                    $"&timezone={Uri.EscapeDataString(timezone)}" +
                    $"&forecast_days={days}" +
                    $"&wind_speed_unit=ms";

                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadFromJsonAsync<DailyWeatherModel>()
                        .ConfigureAwait(false);
                    return model ?? new DailyWeatherModel();
                }
                else
                {
                    throw new InvalidOperationException(response?.RequestMessage?.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the hourly weather data for the specified location and time zone over a given number of forecast
        /// days.
        /// </summary>
        /// <param name="days"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="timezone"></param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see
        /// cref="HourlyWeatherModel"/> with the current weather information for the specified location and time zone.</returns>
        /// <exception cref="Exception"></exception>
        public async Task<HourlyWeatherModel> GetHourlyWeather(int days, double latitude, double longitude, string timezone) 
        {
            try
            {
                string hourly =
                    "temperature_2m,apparent_temperature,precipitation_probability,precipitation,rain,snowfall,weather_code,wind_speed_10m," +
                    "wind_gusts_10m,wind_direction_10m,snow_depth,visibility,cloud_cover,surface_pressure,freezing_level_height";

                var url =
                    $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                    $"&hourly={Uri.EscapeDataString(hourly)}" +
                    $"&timezone={Uri.EscapeDataString(timezone)}" +
                    $"&forecast_days={days}" +
                    $"&wind_speed_unit=ms";

                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadFromJsonAsync<HourlyWeatherModel>()
                        .ConfigureAwait(false);
                    return model ?? new HourlyWeatherModel();
                }
                else
                {
                    throw new InvalidOperationException(response?.RequestMessage?.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
