using System.Text.Json.Serialization;

namespace wetter.Models.WeatherCode
{
    internal class Night
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;
    }
}
