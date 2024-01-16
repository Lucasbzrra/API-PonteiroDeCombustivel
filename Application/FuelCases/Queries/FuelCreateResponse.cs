using Domain.Entities;

namespace Application.FuelCases.Queries;

public sealed record FuelCreateResponse
{
    public double QuantityOfLiters { get; set; }
    public TypFuelEnum TypFuelEnum { get; set; }
    public double ValuePerLiter { get; set; }
    public string SupplyDate { get; set; }
    
}