using Application.VehicleCases.CreateVehicle.Query;
using MediatR;

namespace Application.VehicleCases.CreateVehicle.Command;

public sealed record ReadVehicleRequestDto(Guid id) : IRequest<ReadVehicleResponseDto>;
