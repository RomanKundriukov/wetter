using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WettwerResponses.CurrentWeatherResponse
{
    internal class CurrentWeather
    {
        [JsonPropertyName("time")]
        internal DateTime Time { get; set; }

        [JsonPropertyName("interval")]
        internal int Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        internal double Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        internal int RelativeHumidity { get; set; }

        [JsonPropertyName("rain")]
        internal double Rain { get; set; }

        [JsonPropertyName("snowfall")]
        internal double Snowfall { get; set; }

        [JsonPropertyName("weather_code")]
        internal int WeatherCode { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        internal double WindSpeed { get; set; }

        [JsonPropertyName("apparent_temperature")]
        internal double ApparentTemperature { get; set; }

        [JsonPropertyName("precipitatioin")]
        internal double Precipitation { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        internal int WindDirection { get; set; }

        [JsonPropertyName("wind_gusts_10m")]
        internal double WindGusts { get; set; }
    }
}
