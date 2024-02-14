
namespace Domain.Entities;

public class Fuel : BaseEntity
{
    private static int nextIdFuel = 1;
    public int IdFuel { get; }
    public Fuel()
    {
        IdFuel = nextIdFuel;
        nextIdFuel++;
    }


    public double QuantityOfLiters { get; set; }


    public  TypFuelEnum  typeFuel { get; set; }


    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; } 

    public Guid VehicleID { get; set; }
    public virtual Vehicle Vehicle { get; set; }

    public Guid? DepartureLocationId { get; set; }
    public virtual DepartureLocation? DepartureLocation { get; set; }

    public Guid? DestinationId { get; set; }
    public virtual Destination? Destination { get; set; }


}
