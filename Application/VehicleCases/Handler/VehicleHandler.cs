using Application.VehicleCases.CreateVehicle.Command;
using Application.VehicleCases.CreateVehicle.Queries;
using Application.VehicleCases.CreateVehicle.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.VehicleCases.Handler;

public class VehicleHandller : IRequestHandler<CreateVehicleRequestDto, CreateVehicleResponseDto>,
                                     IRequestHandler<ReadVehicleRequestDto, ReadVehicleResponseDto>,
                                     IRequestHandler<DeleteVehicleRequestDto, DeleteVehicleResponseDto>,
                                     IRequestHandler<UpdateVehicleRequesDto, UpdateVehicleResponseDto>
                                     

{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IMapper _mapper;
    public VehicleHandller(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _vehicleRepository = vehicleRepository;
        _mapper = mapper;
    }
    public async Task<CreateVehicleResponseDto> Handle(CreateVehicleRequestDto request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(request);
        _vehicleRepository.Create(vehicle);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateVehicleResponseDto>(vehicle);
    }

    public async Task<ReadVehicleResponseDto> Handle(ReadVehicleRequestDto request, CancellationToken cancellationToken)
    {
        var VehicleFound = await _vehicleRepository.Get(request.id, cancellationToken);
        return _mapper.Map<ReadVehicleResponseDto>(VehicleFound);
    }

    public async Task<DeleteVehicleResponseDto> Handle(DeleteVehicleRequestDto request, CancellationToken cancellationToken)
    {
        var VehicleFound = await _vehicleRepository.Get(request.Id, cancellationToken);
        if (VehicleFound == null) { return default; }
        _vehicleRepository.Delete(VehicleFound);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<DeleteVehicleResponseDto>(VehicleFound);

    }

    public async Task<UpdateVehicleResponseDto> Handle(UpdateVehicleRequesDto request, CancellationToken cancellationToken)
    {
        var VehicleFound = await _vehicleRepository.GetByVehicle(request.plate, cancellationToken);
        if (VehicleFound == null) { return default; }
        _mapper.Map(request, VehicleFound);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<UpdateVehicleResponseDto>(VehicleFound);
    }
}
