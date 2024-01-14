using Domain.Entities;

namespace Application.DepartureLocationCases.Query;

public class UpdateDeparureLocationResponse
{
    string City { get; set; }

    string UF { get; set; }

    string? ReferencePoint { get; set; }
    public Guid FuelId { get; set; }
    public Fuel Fuel { get; set; }
}