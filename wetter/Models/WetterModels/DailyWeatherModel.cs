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
    internal class DailyWeatherModel
    {
        [JsonPropertyName("latitude")]
        internal double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        internal double Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        internal double GenerationtimeMs { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        internal int UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        internal string? Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        internal string? TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]
        internal double Elevation { get; set; }

        [JsonPropertyName("daily_units")]
        internal DailyUnits DailyUnits { get; set; } = new();

        [JsonPropertyName("daily")]
        internal DailyWeather DailyWeather { get; set; } = new();
    }
}
