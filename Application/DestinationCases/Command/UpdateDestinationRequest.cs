using Application.DestinationCases.Query;
using Domain.Entities;
using MediatR;

namespace Application.DestinationCases.Command;

public sealed record class UpdateDestinationRequest(Guid idDestination,string Country, string Cep, string City, string UF, string? ReferencePoint,string lat, string lng, Guid FuelId) :IRequest<UpdateDestinationResponse>;