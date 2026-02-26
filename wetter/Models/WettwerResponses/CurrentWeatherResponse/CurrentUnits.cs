using System.Text.Json.Serialization;

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
    internal class CurrentUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

        [JsonPropertyName("interval")]
        public string Interval { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m")]
        public string Temperature { get; set; } = string.Empty;

        [JsonPropertyName("relative_humidity_2m")]
        public string RelativeHumidity { get; set; } = string.Empty;

        [JsonPropertyName("rain")]
        public string Rain { get; set; } = string.Empty;

        [JsonPropertyName("snowfall")]
        public string Snowfall { get; set; } = string.Empty;

        [JsonPropertyName("weather_code")]
        public string WeatherCode { get; set; } = string.Empty;

        [JsonPropertyName("wind_speed_10m")]
        public string WindSpeed { get; set; } = string.Empty;

        [JsonPropertyName("apparent_temperature")]
        public string ApparentTemperature { get; set; } = string.Empty;

        [JsonPropertyName("precipitation")]
        public string Precipitation { get; set; } = string.Empty;

        [JsonPropertyName("wind_direction_10m")]
        public string WindDirection { get; set; } = string.Empty;

        [JsonPropertyName("wind_gusts_10m")]
        public string WindGuest { get; set; } = string.Empty;

        [JsonPropertyName("is_day")]
        public string IsDay { get; set; } = string.Empty;
    }
}
