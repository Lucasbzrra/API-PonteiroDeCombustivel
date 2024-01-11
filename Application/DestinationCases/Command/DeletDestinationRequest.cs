using Application.DestinationCases.Query;
using MediatR;


namespace Application.DestinationCases.Command;

public sealed record  DeletDestinationRequest(int IdDestination) : IRequest<DeletDestinationResponse>;
