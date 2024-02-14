
using Application.DestinationCases.Query;
using MediatR;

namespace Application.DestinationCases.Command;

public sealed record  ReadDestinationResquet(Guid IdDestination) : IRequest<ReadDestinationResponse>;
