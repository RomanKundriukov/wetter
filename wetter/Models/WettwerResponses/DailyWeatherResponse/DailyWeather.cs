using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.DailyWeatherResponse
{
    public class DailyWeather
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
