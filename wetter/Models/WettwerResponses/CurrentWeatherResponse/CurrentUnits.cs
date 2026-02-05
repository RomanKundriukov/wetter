using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.CurrentWeatherResponse
{
    /// <summary>
    /// Represents the units of measurement for current weather data fields as provided by a weather API response.
    /// </summary>
    /// <remarks>This class is typically used to describe the units associated with each weather parameter in
    /// a data payload, such as temperature, humidity, precipitation, and wind speed. Each property corresponds to a
    /// specific weather metric and indicates the unit in which its values are reported (for example, degrees Celsius,
    /// millimeters, or kilometers per hour). The properties are mapped to their respective JSON fields for
    /// serialization and deserialization purposes.</remarks>
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
