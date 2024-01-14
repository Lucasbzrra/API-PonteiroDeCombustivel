
using System.Text.Json.Serialization;

namespace Domain.EntitiesExternal;

public sealed class Finaly
{
    [JsonPropertyName("results")]
    public IList<Result> results { get; set; }
}
