using Domain.Entities;

namespace Application.FuelCases.Handlers;

public class FuelDeleteResponse
{

    public double QuantityOfLiters { get; set; }


    public TypFuelEnum typeFuel { get; set; }


    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; }

    public Vehicle Vehicle { get; set; }
    public virtual Guid VehicleId { get; set; }

    public DepartureLocation departureLocation { get; set; }
    public virtual Guid DepartureLocationId { get; set; }

    public Destination destination { get; set; }
    public virtual Guid DestinationId { get; set; }
}