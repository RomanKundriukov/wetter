using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wetter.Models.WettwerResponses.CurrentWeatherResponse;

namespace wetter.Models.WetterModels
{
    /// <summary>
    /// Represents the current weather data for a specific geographic location, including coordinates, time zone
    /// information, elevation, and weather measurements.
    /// </summary>
    /// <remarks>This model is typically used to deserialize responses from weather APIs that provide
    /// real-time weather information. It contains both metadata about the location and the units used, as well as the
    /// actual weather measurements. All properties correspond to fields commonly found in weather service responses and
    /// are mapped for convenient access in .NET applications.</remarks>
    public class CurrentWeatherModel
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

        [JsonPropertyName("current_units")]
        public CurrentUnits CurrentUnits { get; set; } = new();

        [JsonPropertyName("current")]
        public CurrentWeather CurrentWeather { get; set; } = new();
    }
}
