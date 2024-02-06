using Application.FuelCases.Queries;
using Domain.Entities;
using MediatR;
namespace Application.FuelCases.Command;

public sealed record  FuelCreateRequest(double QuantityOfLiters, int typeFuel, double ValuePerLiter, string SupplyDate , Guid VehicleID,DepartureLocation ? departureLocationId, Destination ? DestinationId) :IRequest<FuelCreateResponse>;

