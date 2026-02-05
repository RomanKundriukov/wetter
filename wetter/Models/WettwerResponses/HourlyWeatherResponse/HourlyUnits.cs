using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.HourlyWeatherResponse
{
    internal class HourlyUnits
    {
        [JsonPropertyName("time")]
        internal string Time { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m")]
        internal string Temperature { get; set; } = string.Empty;

        [JsonPropertyName("apparent_temperature")]
        internal string ApparentTemperature { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_probability")]
        internal string PrecipitationProbability { get; set; } = string.Empty;

        [JsonPropertyName("precipitation")]
        internal string Precipitation { get; set; } = string.Empty;

        [JsonPropertyName("rain")]
        internal string Rain { get; set; } = string.Empty;

        [JsonPropertyName("snowfall")]
        internal string Snowfall { get; set; } = string.Empty;

        [JsonPropertyName("weather_code")]
        internal string WeatherCode { get; set; } = string.Empty;

        [JsonPropertyName("wind_speed_10m")]
        internal string WindSpeed { get; set; } = string.Empty;

        [JsonPropertyName("wind_guest_10m")]
        internal string WindGuest { get; set; } = string.Empty;

        [JsonPropertyName("wind_direction_10m")]
        internal string WindDirection { get; set; } = string.Empty;

        [JsonPropertyName("snow_deepth")]
        internal string SnowDeepth { get; set; } = string.Empty;

        [JsonPropertyName("visibility")]
        internal string Visibility { get; set; } = string.Empty;

        [JsonPropertyName("cloud_cover")]
        internal string CloudCover { get; set; } = string.Empty;

        [JsonPropertyName("surface_pressure")]
        internal string SurfacePressure { get; set; } = string.Empty;

        [JsonPropertyName("freezing_level_height")]
        internal string FreezingLevelHeight { get; set; } = string.Empty;
    }
}
