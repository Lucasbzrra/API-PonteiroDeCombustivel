using Domain.Entities;
using MediatR;
namespace Application.FuelCases.Command;

public sealed record  FuelCreateRequest(double QuantityOfLiters, TypFuelEnum TypFuelEnum, double ValuePerLiter, string SupplyDate , Vehicle Vehicle, DepartureLocation departureLocation, Destination Destination) :IRequest<FuelCreateResponse>;

