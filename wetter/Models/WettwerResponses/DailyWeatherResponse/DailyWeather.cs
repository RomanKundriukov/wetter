using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.DailyWeatherResponse
{
    internal class DailyWeather
    {
        [JsonPropertyName("time")]
        internal List<DateTime>? Time { get; set; }

        [JsonPropertyName("weather_code")]
        internal List<int>? WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        internal List<double>? TemperatureMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        internal List<double>? TemperatureMin { get; set; }

        [JsonPropertyName("precipitation_sum")]
        internal List<double>? PrecipitationSum { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        internal List<int>? PrecipitationProbabilityMax { get; set; }

        [JsonPropertyName("rain_sum")]
        internal List<double>? RainSum { get; set; }

        [JsonPropertyName("snowfall_sum")]
        internal List<double>? SnowfallSum { get; set; }

        [JsonPropertyName("sunrise")]
        internal List<DateTime>? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        internal List<DateTime>? Sunset { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        internal List<double>? WindSpeed { get; set; }

        [JsonPropertyName("wind_gusts_10m_max")]
        internal List<double>? WindGusts { get; set; }
    }
}
