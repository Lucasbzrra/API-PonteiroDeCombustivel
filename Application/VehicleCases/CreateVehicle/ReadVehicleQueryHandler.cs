using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.VehicleCases.CreateVehicle;

public  class ReadVehicleQueryHandler : IRequestHandler<ReadVehicleRequestDto , ReadVehicleResponseDto>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    public ReadVehicleQueryHandler(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }

    public async Task<ReadVehicleResponseDto> Handle(ReadVehicleRequestDto request, CancellationToken cancellationToken)
    {
        var vehicleFound = await _vehicleRepository.Get(request.id, cancellationToken);
        return _mapper.Map<ReadVehicleResponseDto>(vehicleFound);
    }


}
