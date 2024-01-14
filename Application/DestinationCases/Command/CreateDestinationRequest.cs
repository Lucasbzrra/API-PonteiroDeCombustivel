using Application.DestinationCases.Query;
using MediatR;
namespace Application.DestinationCases.Command;

public sealed record CreateDestinationRequest(string Country, string Cep, string City, string UF, string? ReferencePoint, Guid FuelIdd):IRequest<CreateDestinationResponse>;