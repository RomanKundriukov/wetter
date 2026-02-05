using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.CurrentWeatherResponse
{
    internal class CurrentUnits
    {
        [JsonPropertyName("time")]
        internal DateTime Time { get; set; }

        [JsonPropertyName("interval")]
        internal string Interval { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m")]
        internal string Temperature { get; set; } = string.Empty;

        [JsonPropertyName("relative_humidity_2m")]
        internal string RelativeHumidity { get; set; } = string.Empty;
        
        [JsonPropertyName("rain")]
        internal string Rain {get; set; } = string.Empty;

        [JsonPropertyName("snowfall")]
        internal string Snowfall { get; set;  } = string.Empty;

        [JsonPropertyName("weather_code")]
        internal string WeatherCode { get; set; } = string.Empty;

        [JsonPropertyName("wind_speed_10m")]
        internal string WindSpeed {  get; set; } = string.Empty;

        [JsonPropertyName("apparent_temperature")]
        internal string ApparentTemperature {  get; set; } = string.Empty;

        [JsonPropertyName("precipitation")]
        internal string Precipitation {  get; set; } = string.Empty;

        [JsonPropertyName("wind_direction_10m")]
        internal string WindDirection {  get; set; } = string.Empty;

        [JsonPropertyName("wind_guest_10m")]
        internal string WindGuest {  get; set; } = string.Empty;
    }
}
