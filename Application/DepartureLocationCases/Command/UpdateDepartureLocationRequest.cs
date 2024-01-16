using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record UpdateDepartureLocationRequest(int idDepartureLocation, string Country, string Cep, string City, string UF, string? ReferencePoint, Guid FuelIdd) : IRequest<UpdateDeparureLocationResponse>;