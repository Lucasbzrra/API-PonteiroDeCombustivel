using Application.FuelCases.Queries;
using Domain.Entities;
using MediatR;
namespace Application.FuelCases.Command;

public sealed record  FuelCreateRequest(double QuantityOfLiters, TypFuelEnum TypFuelEnum, double ValuePerLiter, string SupplyDate , Guid VehicleId, DepartureLocation ? departureLocationId, Destination ? DestinationId) :IRequest<FuelCreateResponse>;

