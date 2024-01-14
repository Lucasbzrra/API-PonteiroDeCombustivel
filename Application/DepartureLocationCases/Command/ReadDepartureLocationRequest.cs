using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record ReadDepartureLocationRequest(int idDepartureLocation) : IRequest<ReadDepartureLocationResponse>;