using Domain.Entities;

namespace Application.DepartureLocationCases.Query;

public class UpdateDeparureLocationResponse
{
   public string City { get; set; }

   public string UF { get; set; }

   public string? ReferencePoint { get; set; }
    public Guid FuelId { get; set; }
    public Fuel Fuel { get; set; }
}