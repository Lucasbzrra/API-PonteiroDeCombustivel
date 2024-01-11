using System.ComponentModel.DataAnnotations;

namespace Application.DestinationCases.Query;

public class UpdateDestinationResponse
{
    public int IdDestination { get; }
    public string City { get; set; }
    public string UF { get; set; }

    public string? ReferencePoint { get; set; }
}