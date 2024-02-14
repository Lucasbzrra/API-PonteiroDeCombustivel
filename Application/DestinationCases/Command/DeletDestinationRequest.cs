using Application.DestinationCases.Query;
using MediatR;


namespace Application.DestinationCases.Command;

public sealed record  DeletDestinationRequest(Guid IdDestination) : IRequest<DeletDestinationResponse>;
