using System.Text.Json.Serialization;

namespace Domain.EntitiesExternal;

public sealed class Geometry
{
    [JsonPropertyName("lat")]
    public double lat { get; set; }
    [JsonPropertyName("lng")]
    public double lng { get; set; }
}