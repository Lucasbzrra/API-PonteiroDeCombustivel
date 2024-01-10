using Domain.Entities;

namespace Application.FuelCases.Queries;

public class FuelReadResponse
{
    public double QuantityOfLiters { get; set; }

    public TypFuelEnum typeFuel { get; set; }

    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; }

    public Vehicle Vehicle { get; set; }

    public DepartureLocation departureLocation { get; set; }

    public Destination destination { get; set; }
}