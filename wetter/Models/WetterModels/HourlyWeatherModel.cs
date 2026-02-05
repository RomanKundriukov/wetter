using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wetter.Models.WettwerResponses.DailyWeatherResponse;
using wetter.Models.WettwerResponses.HourlyWeatherResponse;

namespace wetter.Models.WetterModels
{
    /// <summary>
    /// Represents weather data and metadata for a specific geographic location, including hourly weather observations
    /// and unit information.
    /// </summary>
    /// <remarks>This model is typically used to deserialize hourly weather data from external sources, such
    /// as APIs that provide weather forecasts. It includes location details, time zone information, and structured
    /// hourly weather values. The properties correspond to fields commonly found in weather data feeds and are intended
    /// for use in applications that require detailed, time-based weather information.</remarks>
    internal class HourlyWeatherModel
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double GenerationtimeMs { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string? TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits HourlyUnits { get; set; } = new();

        [JsonPropertyName("hourly")]
        public HourlyWeather HourlyWeather { get; set; } = new();
    }
}
