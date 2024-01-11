using Application.DestinationCases.Query;
using MediatR;
namespace Application.DestinationCases.Command;

public sealed record  CreateDestinationRequest(string City, string UF, string? ReferencePoint, Guid FuelId):IRequest<CreateDestinationResponse>;