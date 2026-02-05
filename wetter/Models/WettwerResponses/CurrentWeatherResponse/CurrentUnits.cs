using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.CurrentWeatherResponse
{
    public class CurrentUnits
    {
        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("interval")]
        public string? Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string? Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public string? RelativeHumidity { get; set; }

        [JsonPropertyName("rain")]
        public string? Rain { get; set; }

        [JsonPropertyName("snowfall")]
        public string? Snowfall { get; set; }

        [JsonPropertyName("weather_code")]
        public string? WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string? WindSpeed { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public string? ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation")]
        public string? Precipitation { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public string? WindDirection { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        public string? WindGuest { get; set; }
    }
}
