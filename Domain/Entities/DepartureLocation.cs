
namespace Domain.Entities;

public class DepartureLocation:BaseEntityLocation
{
    private static int nextIdDeparture = 1;
    public int IdDepartureLocation { get; }
    public DepartureLocation()
    {
        IdDepartureLocation = nextIdDeparture;
        nextIdDeparture++;
    }

    public Guid FuelId { get; set; }
    public  Fuel Fuel { get; set; }
}
