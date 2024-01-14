using Domain.Entities;

namespace Application.DepartureLocationCases.Query;


public class ReadDepartureLocationResponse
{
    public int IdDepartureLocation { get; }
    public string City { get; set; }

    public string UF { get; set; }

    public string? ReferencePoint { get; set; }

    public Guid FuelId { get; set; }
    public Fuel Fuel { get; set; }

}