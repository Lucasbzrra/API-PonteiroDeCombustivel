
namespace Domain.Entities;

public class DepartureLocation:BaseEntityLocation
{
    private static int nextIdDeparture = 0;
    public int IdDepartureLocation { get; }
    public DepartureLocation()
    {
        IdDepartureLocation = nextIdDeparture;
        nextIdDeparture++;
    }

    public Guid FuelId { get; set; }
    public  Fuel Fuel { get; set; }
}
