using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using wetter.Models.WettwerResponses.CurrentWeatherResponse;
using wetter.Models.WettwerResponses.DailyWeatherResponse;

namespace wetter.Models.WetterModels
{
    /// <summary>
    /// Represents daily weather data and associated metadata for a specific geographic location.
    /// </summary>
    /// <remarks>This model includes location coordinates, timezone information, elevation, and daily weather
    /// details. It is typically used to deserialize weather API responses that provide daily forecasts or historical
    /// weather data. The properties correspond to fields commonly found in weather service responses, enabling easy
    /// access to both metadata and daily weather values.</remarks>
    public class DailyWeatherModel
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

        [JsonPropertyName("daily_units")]
        public DailyUnits DailyUnits { get; set; } = new();

        [JsonPropertyName("daily")]
        public DailyWeather DailyWeather { get; set; } = new();
    }
}
