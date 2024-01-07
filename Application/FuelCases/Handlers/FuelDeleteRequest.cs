using MediatR;

namespace Application.FuelCases.Handlers;

public sealed record  FuelDeleteRequest(Guid id):IRequest<FuelDeleteResponse>
{
}