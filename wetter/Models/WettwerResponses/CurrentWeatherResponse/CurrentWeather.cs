using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.CurrentWeatherResponse
{
    /// <summary>
    /// Represents the current weather conditions at a specific time and location, including temperature, humidity,
    /// precipitation, wind, and other meteorological data.
    /// </summary>
    /// <remarks>This class is typically used to deserialize weather data from JSON sources, such as APIs
    /// providing real-time weather information. All properties correspond to standard meteorological measurements and
    /// are mapped to their respective JSON fields. Values are provided in commonly used units: temperature in degrees
    /// Celsius, wind speed in meters per second, precipitation in millimeters, and humidity as a percentage. The
    /// meaning of the weather code depends on the data provider's specification.</remarks>
    internal class CurrentWeather
    {
        [JsonPropertyName("time")]
        public string? Time { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public int RelativeHumidity { get; set; }

        [JsonPropertyName("rain")]
        public double Rain { get; set; }

        [JsonPropertyName("snowfall")]
        public double Snowfall { get; set; }
        [JsonPropertyName("weather_code")]
        public int WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public double ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public int WindDirection { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        public double WindGusts { get; set; }
    }
}
