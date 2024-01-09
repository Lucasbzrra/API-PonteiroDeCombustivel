using Domain.Entities;

namespace Application.FuelCases.Queries;

public sealed record FuelCreateResponse
{
    public double QuantityOfLiters { get; set; }
    public TypFuelEnum TypFuelEnum { get; set; }
    public double ValuePerLiter { get; set; }
    public string SupplyDate { get; set; }
    
    public  Vehicle Vehicle { get; set; }

    public  DepartureLocation departureLocation { get; set; }
    
    public  Destination Destination { get; set; }
}