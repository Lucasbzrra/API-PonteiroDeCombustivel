using Application.DepartureLocationCases.Query;
using MediatR;

namespace Application.DepartureLocationCases.Command;

public sealed record CreateDepartureLocationRequest(string ? Country, string ? Cep, string ? City, string ? UF, string? ReferencePoint, string lat, string lng, Guid FuelId) : IRequest<CreateDepartureLocationResponse>;