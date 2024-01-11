using Application.DestinationCases.Query;
using Domain.Entities;
using MediatR;

namespace Application.DestinationCases.Command;

public sealed record class UpdateDestinationRequest( int IdDestination  , string City, string UF, string? ReferencePoint   ,Guid FuelId, Fuel Fuel ):IRequest<UpdateDestinationResponse>;