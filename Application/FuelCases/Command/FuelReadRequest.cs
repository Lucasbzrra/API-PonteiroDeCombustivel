using Application.FuelCases.Queries;
using MediatR;

namespace Application.FuelCases.Command;

public sealed record FuelReadRequest(Guid id) : IRequest<FuelReadResponse>;