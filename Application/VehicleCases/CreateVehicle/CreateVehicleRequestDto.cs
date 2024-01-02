using MediatR;

namespace Application.VehicleCases.CreateVehicle;


public sealed record CreateVehicleRequestDto(string Name, string Plate, double KmPerLiter):IRequest<CreateVehicleResponseDto>;


