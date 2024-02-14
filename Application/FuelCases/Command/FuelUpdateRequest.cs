using Application.FuelCases.Queries;
using Domain.Entities;
using MediatR;

namespace Application.FuelCases.Command;

public sealed record FuelUpdateRequest(int IdFuel, double QuantityOfLiters, TypFuelEnum typeFuel, double ValuePerLiter, string SupplyDate) : IRequest<FuelUpdateResponse>;