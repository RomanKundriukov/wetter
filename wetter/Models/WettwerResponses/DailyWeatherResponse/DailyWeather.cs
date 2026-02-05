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
        public List<DateTime>? Time { get; set; } 

        [JsonPropertyName("weather_code")]
        public List<int>? WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double>? TemperatureMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double>? TemperatureMin { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<double>? PrecipitationSum { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public List<int>? PrecipitationProbabilityMax { get; set; }

        [JsonPropertyName("rain_sum")]
        public List<double>? RainSum { get; set; }

        [JsonPropertyName("snowfall_sum")]
        public List<double>? SnowfallSum { get; set; }

        [JsonPropertyName("sunrise")]
        public List<DateTime>? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<DateTime>? Sunset { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public List<double>? WindSpeed { get; set; }

        [JsonPropertyName("wind_gusts_10m_max")]
        public List<double>? WindGusts { get; set; }
    }
}
