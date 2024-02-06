using Application.DestinationCases.Query;
using MediatR;
namespace Application.DestinationCases.Command;

public sealed record CreateDestinationRequest( string Cep, string UF, string City, string Country, string lat, string lng,  string? ReferencePoint, Guid FuelIdd):IRequest<CreateDestinationResponse>;