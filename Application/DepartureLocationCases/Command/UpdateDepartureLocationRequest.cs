using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record UpdateDepartureLocationRequest(int idDepartureLocation, string City, string UF, string? ReferencePoint) : IRequest<UpdateDeparureLocationResponse>;