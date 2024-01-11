using Domain.Entities;

namespace Application.DestinationCases.Query;

public class ReadDestinationResponse
{
    public string City { get; set; }

    public string UF { get; set; }

    public string? ReferencePoint { get; set; }

    public int IdDestination { get; set; }
    public Guid FuelId { get; set; }
    public Fuel Fuel { get; set; }
}
