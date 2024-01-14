using Application.VehicleCases.CreateVehicle.Query;
using MediatR;

namespace Application.VehicleCases.CreateVehicle.Command;


public sealed record CreateVehicleRequest(string Name, string Plate, double KmPerLiter) : IRequest<CreateVehicleResponse>;


