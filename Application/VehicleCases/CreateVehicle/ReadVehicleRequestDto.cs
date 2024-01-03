using MediatR;

namespace Application.VehicleCases.CreateVehicle;

public sealed record ReadVehicleRequestDto(Guid id) : IRequest<ReadVehicleResponseDto>;

   
