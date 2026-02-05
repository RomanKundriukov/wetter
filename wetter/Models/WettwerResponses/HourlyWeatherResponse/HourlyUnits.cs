using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.HourlyWeatherResponse
{
    /// <summary>
    /// Represents the units of measurement for hourly weather data fields as provided by a weather API response.
    /// </summary>
    /// <remarks>This class is typically used to describe the units associated with each hourly weather
    /// parameter, such as temperature, precipitation, wind speed, and visibility. Each property corresponds to a
    /// specific weather data field and indicates the unit in which that field's values are reported (for example,
    /// degrees Celsius, millimeters, or meters per second). The properties are nullable to accommodate cases where
    /// certain units may not be specified in the API response.</remarks>
    internal class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string? Temperature { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public string? ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public string? PrecipitationProbability { get; set; }

        [JsonPropertyName("precipitation")]
        public string? Precipitation { get; set; }

        [JsonPropertyName("rain")]
        public string? Rain { get; set; }

        [JsonPropertyName("snowfall")]
        public string? Snowfall { get; set; }

        [JsonPropertyName("weather_code")]
        public string? WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string? WindSpeed { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        public string? WindGuest { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public string? WindDirection { get; set; }

        [JsonPropertyName("snow_depth")]
        public string? SnowDeepth { get; set; }

        [JsonPropertyName("visibility")]
        public string? Visibility { get; set; }

        [JsonPropertyName("cloud_cover")]
        public string? CloudCover { get; set; }

        [JsonPropertyName("surface_pressure")]
        public string? SurfacePressure { get; set; }

        [JsonPropertyName("freezing_level_height")]
        public string? FreezingLevelHeight { get; set; }
    }
}
