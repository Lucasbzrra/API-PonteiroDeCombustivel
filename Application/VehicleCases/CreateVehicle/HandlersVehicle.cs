using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.VehicleCases.CreateVehicle;

public class HandlersVehicle:IRequestHandler<CreateVehicleRequestDto,CreateVehicleResponseDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IVehicleRepository _vehicleRepository;
	private readonly IMapper _mapper;
	public HandlersVehicle(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository, IMapper mapper)
	{
		 _unitOfWork= unitOfWork;
		_vehicleRepository= vehicleRepository;
		_mapper= mapper;
	}
	public async Task<CreateVehicleResponseDto> Handle(CreateVehicleRequestDto request,CancellationToken cancellationToken)
	{
		var user = _mapper.Map<Vehicle>(request);
		_vehicleRepository.Create(user);
		await _unitOfWork.Commit(cancellationToken);
		return _mapper.Map<CreateVehicleResponseDto>(user);
	}
}
