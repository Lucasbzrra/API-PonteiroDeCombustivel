using Application.DepartureLocationCases.Command;
using Application.DepartureLocationCases.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Persistence.Repositories;

namespace Application.DepartureLocationCases.DepartureLocationHandler;

public class DepartureLocationHandler : IRequestHandler<CreateDepartureLocationRequest, CreateDepartureLocationResponse>,
                                        IRequestHandler<ReadDepartureLocationRequest, ReadDepartureLocationResponse>,
                                        IRequestHandler<UpdateDepartureLocationRequest, UpdateDeparureLocationResponse>,
                                        IRequestHandler<DeleteDepartureLocationRequest, DeleteDepartureLocationResponse>
{
    private readonly IMapper _mapper;
    private readonly IDepartureLocationRepository _departureLocationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DepartureLocationHandler(IMapper mapper, IUnitOfWork unitOfWork, IDepartureLocationRepository departure)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _departureLocationRepository = departure;
    }
    public async Task<CreateDepartureLocationResponse> Handle(CreateDepartureLocationRequest request, CancellationToken cancellationToken)
    {
        var DepartureLocation = _mapper.Map<DepartureLocation>(request);
        await _departureLocationRepository.Create(DepartureLocation);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<CreateDepartureLocationResponse>(DepartureLocation);
    }

    public async Task<ReadDepartureLocationResponse> Handle(ReadDepartureLocationRequest request, CancellationToken cancellationToken)
    {
        var DepartureLocationFound = await _departureLocationRepository.Get(request.idDepartureLocation,cancellationToken);
        return _mapper.Map<ReadDepartureLocationResponse>(DepartureLocationFound);
    }

    public async Task<UpdateDeparureLocationResponse> Handle(UpdateDepartureLocationRequest request, CancellationToken cancellationToken)
    {
        var DepartureLocationFound = await _departureLocationRepository.Get(request.idDepartureLocation,cancellationToken);
        if (DepartureLocationFound is null) { return default; }
        _mapper.Map(request, DepartureLocationFound);
         _departureLocationRepository.Update(DepartureLocationFound);
        return _mapper.Map<UpdateDeparureLocationResponse>(DepartureLocationFound);
    }

    public async Task<DeleteDepartureLocationResponse> Handle(DeleteDepartureLocationRequest request, CancellationToken cancellationToken)
    {
        var DepartureLocationFound = _departureLocationRepository.Get(request.idDepartureLocation,cancellationToken);
        if (DepartureLocationFound is null) { return default; }
        DepartureLocation departureLocation = _mapper.Map<DepartureLocation>(DepartureLocationFound);
        await _departureLocationRepository.Delete(departureLocation);
        return _mapper.Map<DeleteDepartureLocationResponse>(departureLocation);
    }
}