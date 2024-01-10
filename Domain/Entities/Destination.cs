namespace Domain.Entities;

public class Destination:BaseEntityLocation
{
    public Guid FuelId { get; set; }
    public  Fuel Fuel { get; set; }
}
