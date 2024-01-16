using Domain.Entities;

namespace Application.FuelCases.Queries;

public class FuelReadResponse
{
    public double QuantityOfLiters { get; set; }

    public TypFuelEnum typeFuel { get; set; }

    public double ValuePerLiter { get; set; }

    public string SupplyDate { get; set; }

  
}