using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.DailyWeatherResponse
{
    /// <summary>
    /// Represents daily weather data, including temperature, precipitation, wind, and astronomical information for a
    /// series of dates.
    /// </summary>
    /// <remarks>This class is typically used to deserialize daily weather forecasts or historical weather
    /// data from JSON sources. Each property contains a list of values corresponding to each day in the forecast or
    /// dataset. The lists are expected to be of equal length, where each index represents the same day across all
    /// properties. Properties may be null if the data source does not provide values for a particular field.</remarks>
    internal class DailyWeather
    {
        [JsonPropertyName("time")]
        public List<DateTime> Time { get; set; } = new();

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = new();

        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax { get; set; } = new();

        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin { get; set; } = new();

        [JsonPropertyName("precipitation_sum")]
        public List<double> PrecipitationSum { get; set; } = new();

        [JsonPropertyName("precipitation_probability_max")]
        public List<int> PrecipitationProbabilityMax { get; set; } = new();

        [JsonPropertyName("rain_sum")]
        public List<double> RainSum { get; set; } = new();

        [JsonPropertyName("snowfall_sum")]
        public List<double> SnowfallSum { get; set; } = new();

        [JsonPropertyName("sunrise")]
        public List<DateTime> Sunrise { get; set; } = new();

        [JsonPropertyName("sunset")]
        public List<DateTime> Sunset { get; set; } = new();

        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> WindSpeed { get; set; } = new();

        [JsonPropertyName("wind_gusts_10m_max")]
        public List<double> WindGusts { get; set; } = new();
    }
}
