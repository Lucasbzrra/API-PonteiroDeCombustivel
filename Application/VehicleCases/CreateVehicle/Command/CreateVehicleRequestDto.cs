using Application.VehicleCases.CreateVehicle.Query;
using MediatR;

namespace Application.VehicleCases.CreateVehicle.Command;


public sealed record CreateVehicleRequestDto(string Name, string Plate, double KmPerLiter) : IRequest<CreateVehicleResponseDto>;


