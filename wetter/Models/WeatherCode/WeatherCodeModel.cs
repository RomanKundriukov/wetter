using System.Text.Json.Serialization;

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
