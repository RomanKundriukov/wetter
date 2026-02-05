using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.DailyWeatherResponse
{
    internal class DailyUnits
    {
        [JsonPropertyName("time")]
        internal string Time { get; set; } = string.Empty;

        [JsonPropertyName("weather_code")]
        internal string WeatherCode { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m_max")]
        internal string TemperatureMax { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m_min")]
        internal string TemperatureMin { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_sum")]
        internal string PrecipitationSum { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_probability_max")]
        internal string PrecipitationProbabilityMax { get; set; } = string.Empty;

        [JsonPropertyName("rain_sum")]
        internal string RainSum { get; set; } = string.Empty;

        [JsonPropertyName("snowfall_sum")]
        internal string SnowfallSum { get; set; } = string.Empty;

        [JsonPropertyName("sunrise")]
        internal string Sunrise { get; set; } = string.Empty;

        [JsonPropertyName("sunset")]
        internal string Sunset { get; set; } = string.Empty;

        [JsonPropertyName("wind_speed_10m_max")]
        internal string WindSpeed { get; set; } = string.Empty;

        [JsonPropertyName("wind_guest_10m_max")]
        internal string WindGuest { get; set; } = string.Empty;
    }
}
