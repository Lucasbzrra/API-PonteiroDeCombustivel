
namespace Domain.Entities;

public class DepartureLocation:BaseEntityLocation
{
    public Guid FuelId { get; set; }
    public  Fuel Fuel { get; set; }
}
