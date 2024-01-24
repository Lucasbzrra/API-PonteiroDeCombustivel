
using System.ComponentModel.DataAnnotations;

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

    [Required]
    [Range(1, 50)]
    public double QuantityOfLiters { get; set; }

    [Required]
    public  TypFuelEnum  typeFuel { get; set; }


    [Range(1, double.MaxValue)]
    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; } 

    public Guid VehicleID { get; set; }
    public virtual Vehicle Vehicle { get; set; }

    public Guid? departureLocationId { get; set; }
    public DepartureLocation? departureLocation { get; set; }

    public Guid? destinationId { get; set; }
    public Destination? destination { get; set; }


}
