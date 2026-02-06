using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wetter.Models.WetterModels;
using Windows.Globalization;

namespace wetter.Services
{
    /// <summary>
    /// Provides methods for retrieving weather forecast data, including current, daily, and hourly weather information
    /// for a specified location.
    /// </summary>
    /// <remarks>This interface defines asynchronous operations for obtaining weather forecasts based on
    /// geographic coordinates and time zone. Implementations may source data from external weather APIs or services.
    /// All methods require valid latitude and longitude values, and the number of days requested may be subject to
    /// service-specific limits.</remarks>
    internal interface IWeatherForecastService
    {
        Task<CurrentWeatherModel> GetCurrentWeatherAsync(int days, double latitude, double longitude, string timezone);

        Task<DailyWeatherModel> GetDailyWeatherAsync(int days, double latitude, double longitude, string timezone);

        Task<HourlyWeatherModel> GetHourlyWeatherAsync(int days, double latitude, double longitude, string timezone);

    }
}

