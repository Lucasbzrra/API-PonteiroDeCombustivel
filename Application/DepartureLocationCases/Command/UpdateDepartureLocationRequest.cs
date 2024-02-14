using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record UpdateDepartureLocationRequest(Guid idDepartureLocation, string Country, string Cep, string City, string UF, string? ReferencePoint, string lat, string lng , Guid FuelIdd) : IRequest<UpdateDeparureLocationResponse>;