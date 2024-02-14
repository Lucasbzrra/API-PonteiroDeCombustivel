using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.EntitiesExternal;

public sealed class Components
{
    [JsonPropertyName("ISO_3166-1_alpha-2")]
    public string ISO_31661_alpha2 { get; set; }

    [JsonPropertyName("ISO_3166-1_alpha-3")]
    public string ISO_31661_alpha3 { get; set; }

    [JsonPropertyName("ISO_3166-2")]
    public List<string> ISO_31662 { get; set; }
    public string _category { get; set; }
    public string _normalized_city { get; set; }
    public string _type { get; set; }
    public string city { get; set; }
    public string continent { get; set; }
    public string country { get; set; }
    public string country_code { get; set; }
    public string county { get; set; }
    public string municipality { get; set; }
    public string neighbourhood { get; set; }
    public string postcode { get; set; }
    public string railway { get; set; }
    public string region { get; set; }
    public string road { get; set; }
    public string state { get; set; }
    public string state_code { get; set; }
    public string state_district { get; set; }
    public string road_type { get; set; }
    public string suburb { get; set; }
}