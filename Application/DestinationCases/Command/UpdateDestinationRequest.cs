using Application.DestinationCases.Query;
using Domain.Entities;
using MediatR;

namespace Application.DestinationCases.Command;

public sealed record class UpdateDestinationRequest(int idDestination,string Country, string Cep, string City, string UF, string? ReferencePoint, Guid FuelIdd) :IRequest<UpdateDestinationResponse>;