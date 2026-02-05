using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wetter.Models.LocationsModel
{
    /// <summary>
    /// Represents a location result returned from a geocoding or mapping API, containing identifiers, coordinates,
    /// descriptive information, and address details.
    /// </summary>
    /// <remarks>This model is typically used to deserialize location data from external services such as
    /// OpenStreetMap or similar geocoding providers. It includes both raw identifiers and human-readable fields, as
    /// well as a structured address. Thread safety is not guaranteed; if multiple threads access an instance
    /// concurrently, external synchronization is required.</remarks>
    internal class LocationModel
    {
        [JsonPropertyName("place_id")]
        public int PlaceId { get; set; }

        [JsonPropertyName("licence")]
        public string? Licence { get; set; }

        [JsonPropertyName("osm_type")]
        public string? OsmType { get; set; }

        [JsonPropertyName("osm_id")]
        public long OsmId { get; set; }

        [JsonPropertyName("lat")]
        public string? Latitude { get; set; }

        [JsonPropertyName("lon")]
        public string? Longitude { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("addresstype")]
        public string? AddressType { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("display_name")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("address")]
        public LocationAddress Address { get; set; } = new();

        [JsonPropertyName("boundingbox")]
        public List<double>? boundingbox {  get; set; }
    }
}
