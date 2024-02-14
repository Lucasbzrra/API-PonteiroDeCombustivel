using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record ReadDepartureLocationRequest(Guid idDepartureLocation) : IRequest<ReadDepartureLocationResponse>;