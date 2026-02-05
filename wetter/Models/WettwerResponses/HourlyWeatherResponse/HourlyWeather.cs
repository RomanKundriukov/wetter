using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.HourlyWeatherResponse
{
    internal class HourlyWeather
    {
        [JsonPropertyName("time")]
        internal List<DateTime>? Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        internal List<double>? Temperature { get; set; }

        [JsonPropertyName("apparent_temperature")]
        internal List<double>? ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation_probability")]
        internal List<int>? PrecipitationProbability { get; set; }

        [JsonPropertyName("precipitation")]
        internal List<double>? Precipitation { get; set; }

        [JsonPropertyName("rain")]
        internal List<double>? Rain { get; set; }

        [JsonPropertyName("snowfall")]
        internal List<double>? Snowfall { get; set; }

        [JsonPropertyName("weather_code")]
        internal List<int>? WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        internal List<double>? WindSpeed { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        internal List<double>? WindGusts { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        internal List<int>? WindDirection { get; set; }

        [JsonPropertyName("snow_depth")]
        internal List<double>? SnowDepth { get; set; }

        [JsonPropertyName("visibility")]
        internal List<double>? Visibility { get; set; }

        [JsonPropertyName("cloud_cover")]
        internal List<int>? CloudCover { get; set; }

        [JsonPropertyName("surface_pressure")]
        internal List<double>? SurfacePressure { get; set; }

        [JsonPropertyName("freezing_level_height")]
        internal List<double>? FreezingLevelHeight { get; set; }
    }
}
