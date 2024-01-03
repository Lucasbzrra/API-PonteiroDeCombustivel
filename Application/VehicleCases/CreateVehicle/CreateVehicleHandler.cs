using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.VehicleCases.CreateVehicle;

public class CreateVehicleHandller : IRequestHandler<CreateVehicleRequestDto, CreateVehicleResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IVehicleRepository _vehicleRepository;
	private readonly IMapper _mapper;
	public CreateVehicleHandller(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository, IMapper mapper)
	{
		 _unitOfWork= unitOfWork;
		_vehicleRepository= vehicleRepository;
		_mapper= mapper;
	}
    public async Task<CreateVehicleResponseDto> Handle(CreateVehicleRequestDto request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(request);
        _vehicleRepository.Create(vehicle);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateVehicleResponseDto>(vehicle);
    }

}
