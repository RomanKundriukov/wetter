using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    internal class HourlyWeather
    {
        [JsonPropertyName("time")]
        public List<DateTime> Time { get; set; } = new();

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; } = new();

        [JsonPropertyName("uv_index")]
        public List<double> UVIndex { get; set; } = new();

        [JsonPropertyName("apparent_temperature")]
        public List<double> ApparentTemperature { get; set; } = new();

        [JsonPropertyName("precipitation_probability")]
        public List<int> PrecipitationProbability { get; set; } = new();

        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; } = new();

        [JsonPropertyName("rain")]
        public List<double> Rain { get; set; } = new();

        [JsonPropertyName("snowfall")]
        public List<double> Snowfall { get; set; } = new();

        [JsonPropertyName("weather_code")]
        public List<int>? WeatherCode { get; set; } = new();

        [JsonPropertyName("wind_speed_10m")]
        public List<double> WindSpeed { get; set; } = new();

        [JsonPropertyName("wind_gusts_10m")]
        public List<double> WindGusts { get; set; } = new();

        [JsonPropertyName("wind_direction_10m")]
        public List<int> WindDirection { get; set; } = new();

        [JsonPropertyName("snow_depth")]
        public List<double> SnowDepth { get; set; } = new();

        [JsonPropertyName("visibility")]
        public List<double> Visibility { get; set; } = new();

        [JsonPropertyName("cloud_cover")]
        public List<int> CloudCover { get; set; } = new();

        [JsonPropertyName("surface_pressure")]
        public List<double> SurfacePressure { get; set; } = new();

        [JsonPropertyName("freezing_level_height")]
        public List<double> FreezingLevelHeight { get; set; } = new();
    }
}
