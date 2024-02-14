using Application.FuelCases.Queries;
using Application.VehicleCases.CreateVehicle.Command;
using Application.VehicleCases.CreateVehicle.Queries;
using Application.VehicleCases.CreateVehicle.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Persistence.Repositories;

namespace Application.VehicleCases.Handler;

public class VehicleHandller : IRequestHandler<CreateVehicleRequest, CreateVehicleResponse>,
                                     IRequestHandler<ReadVehicleRequest, ReadVehicleResponse>,
                                     IRequestHandler<DeleteVehicleRequest, DeleteVehicleResponse>,
                                     IRequestHandler<UpdateVehicleReques, UpdateVehicleResponse>
                                     

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
    public async Task<CreateVehicleResponse> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<Vehicle>(request);
        _vehicleRepository.Create(vehicle);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateVehicleResponse>(vehicle);
    }

    public async Task<ReadVehicleResponse> Handle(ReadVehicleRequest request, CancellationToken cancellationToken)
    {
        var VehicleFound = await _vehicleRepository.Get(request.id, cancellationToken);
        return _mapper.Map<ReadVehicleResponse>(VehicleFound);
    }

    public async Task<DeleteVehicleResponse> Handle(DeleteVehicleRequest request, CancellationToken cancellationToken)
    {
        var VehicleFound = await _vehicleRepository.Get(request.Id, cancellationToken);
        if (VehicleFound == null) { return default; }
        _vehicleRepository.Delete(VehicleFound);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<DeleteVehicleResponse>(VehicleFound);


    }

    public async Task<UpdateVehicleResponse> Handle(UpdateVehicleReques request, CancellationToken cancellationToken)
    {
        var VehicleFound = await _vehicleRepository.Get(request.id, cancellationToken);
        if (VehicleFound is null) { return default; }
        _mapper.Map(request, VehicleFound);
        _vehicleRepository.Update(VehicleFound);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<UpdateVehicleResponse>(VehicleFound);
    }
}
