using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.HourlyWeatherResponse
{
    /// <summary>
    /// Represents a collection of hourly weather data, including temperature, precipitation, wind, and other
    /// atmospheric conditions for each hour.
    /// </summary>
    /// <remarks>Each property contains a list of values corresponding to hourly measurements. The lists are
    /// typically aligned by index, where each index represents the same hour across all properties. This class is
    /// commonly used to deserialize weather forecast data from JSON sources. All properties are nullable; if a property
    /// is null, the corresponding data is unavailable for that hour.</remarks>
    public class HourlyWeather
    {
        [JsonPropertyName("time")]
        public List<DateTime>? Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double>? Temperature { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public List<double>? ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation_probability")]
        public List<int>? PrecipitationProbability { get; set; }

        [JsonPropertyName("precipitation")]
        public List<double>? Precipitation { get; set; }

        [JsonPropertyName("rain")]
        public List<double>? Rain { get; set; }

        [JsonPropertyName("snowfall")]
        public List<double>? Snowfall { get; set; }

        [JsonPropertyName("weather_code")]
        public List<int>? WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public List<double>? WindSpeed { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        public List<double>? WindGusts { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public List<int>? WindDirection { get; set; }

        [JsonPropertyName("snow_depth")]
        public List<double>? SnowDepth { get; set; }

        [JsonPropertyName("visibility")]
        public List<double>? Visibility { get; set; }

        [JsonPropertyName("cloud_cover")]
        public List<int>? CloudCover { get; set; }

        [JsonPropertyName("surface_pressure")]
        public List<double>? SurfacePressure { get; set; }

        [JsonPropertyName("freezing_level_height")]
        public List<double>? FreezingLevelHeight { get; set; }
    }
}
