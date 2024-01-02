
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Fuel
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [Range(1, 50)]
    public double QuantityOfLiters { get; set; }

    [Required]
    [Range(1,2,ErrorMessage ="1-Gasol, 2-Etanol")]
    public TypFuelEnum typeFuel { get; set; }


    [Range(1, double.MaxValue)]
    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; }

    public Vehicle Vehicle { get; set; }
    public virtual Guid VehicleId { get; set; }

    public DepartureLocation departureLocation { get; set; }
    public virtual Guid DepartureLocationId { get; set; }

    public Destination destination { get; set; }
    public virtual Guid DestinationId { get; set; }

}
