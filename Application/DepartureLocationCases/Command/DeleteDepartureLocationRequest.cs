using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record DeleteDepartureLocationRequest(Guid idDepartureLocation) : IRequest<DeleteDepartureLocationResponse>;