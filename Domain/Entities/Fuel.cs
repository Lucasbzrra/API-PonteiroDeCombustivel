
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Fuel:BaseEntity
{

    [Required]
    [Range(1, 50)]
    public double QuantityOfLiters { get; set; }

    [Required]
    [Range(1,2,ErrorMessage ="1-Gasol, 2-Etanol")]
    public TypFuelEnum typeFuel { get; set; }


    [Range(1, double.MaxValue)]
    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; }

    public Guid  VehicleId { get; set; }

    public DepartureLocation departureLocationId { get; set; }
    //public virtual Guid ? DepartureLocationId  { get; set; }

    public Destination destinationId { get; set; }
    //public virtual Guid ? DestinationId { get; set; }

}
