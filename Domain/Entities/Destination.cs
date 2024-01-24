namespace Domain.Entities;

public class Destination:BaseEntityLocation
{
    private static int nextIdDestination = 0;
    public int IdDestination { get; }
    public Destination()
    {
        IdDestination = nextIdDestination;
        nextIdDestination++;
    }
    public Guid FuelId { get; set; }
    public Fuel Fuel { get; set; }
}
