using Application.FuelCases.Queries;
using MediatR;

namespace Application.FuelCases.Command;

public sealed record FuelDeleteRequest(Guid id) : IRequest<FuelDeleteResponse>
{
}