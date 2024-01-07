using Domain.Entities;

namespace Application.FuelCases.Command;

public sealed record FuelCreateResponse(double QuantityOfLiters, TypFuelEnum TypFuelEnum, double ValuePerLiter, string SupplyDate, Vehicle Vehicle, DepartureLocation departureLocation, Destination Destination)
{
}