using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.EntitiesExternal;

public sealed class Result
{
    [JsonPropertyName("formatted")]
    public string formatted { get; set; }

    [JsonPropertyName("geometry")]

    public Geometry geometry { get; set; }
    [JsonPropertyName("components")]
   public Components components { get; set; }
}