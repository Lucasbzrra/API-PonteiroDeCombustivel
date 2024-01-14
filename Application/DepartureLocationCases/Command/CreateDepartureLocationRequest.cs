using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record CreateDepartureLocationRequest(string Country, string Cep, string City, string UF, string? ReferencePoint, Guid FuelId) : IRequest<CreateDepartureLocationResponse>;