using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.WeatherCode
{
    internal class WeatherCodeModel
    {
        [JsonPropertyName("day")]
        public Day Day { get; set; } = new();

        [JsonPropertyName("night")]
        public Night Night { get; set; } = new();
    }
}
