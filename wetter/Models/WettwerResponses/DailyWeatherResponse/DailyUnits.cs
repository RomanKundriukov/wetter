using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.DailyWeatherResponse
{
    public class DailyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

        [JsonPropertyName("weather_code")]
        public string WeatherCode { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m_max")]
        public string TemperatureMax { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m_min")]
        public string TemperatureMin { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_sum")]
        public string PrecipitationSum { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_probability_max")]
        public string PrecipitationProbabilityMax { get; set; } = string.Empty;

        [JsonPropertyName("rain_sum")]
        public string RainSum { get; set; } = string.Empty;

        [JsonPropertyName("snowfall_sum")]
        public string SnowfallSum { get; set; } = string.Empty;

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; } = string.Empty;

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; } = string.Empty;

        [JsonPropertyName("wind_speed_10m_max")]
        public string WindSpeed { get; set; } = string.Empty;

        [JsonPropertyName("wind_gusts_10m_max")]
        public string WindGuest { get; set; } = string.Empty;
    }
}
