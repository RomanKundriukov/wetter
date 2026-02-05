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
    internal class WeatherForecastService
    {
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

        internal async Task<CurrentWeatherModel> GetCurrentWeather(int days, double latitude, double longitude, string timezone)
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

        internal async Task<DailyWeatherModel> GetDailyWeather(int days, double latitude, double longitude, string timezone) 
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

        internal HourlyWeatherModel GetHourlyWeather(int days) { return new HourlyWeatherModel(); }
    }
}
