using Application.FuelCases.Command;
using Application.FuelCases.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;


namespace Application.FuelCases.Handlers;

public class FuelHandler:IRequestHandler<FuelCreateRequest,FuelCreateResponse>,
						 IRequestHandler<FuelDeleteRequest,FuelDeleteResponse>
{
	private readonly IFuelRepository _vehicleRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	public FuelHandler(IFuelRepository vehicleRepository, IUnitOfWork unitOfWork, IMapper mapper)
	{
		_vehicleRepository= vehicleRepository;
        _unitOfWork= unitOfWork;
        _mapper= mapper;

	}

    public async Task<FuelCreateResponse> Handle(FuelCreateRequest request, CancellationToken cancellationToken)
    {
        Fuel fuel=  _mapper.Map<Fuel>(request);
        _vehicleRepository.Create(fuel);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<FuelCreateResponse>(fuel);

    }

    public async Task<FuelDeleteResponse> Handle(FuelDeleteRequest request, CancellationToken cancellationToken)
    {
        var FuelFound=  _vehicleRepository.Get(request.id, cancellationToken);
        if(FuelFound is null) { return default; }
        Fuel fuel= _mapper.Map<Fuel>(FuelFound);
        _vehicleRepository.Delete(fuel);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<FuelDeleteResponse>(fuel) ;


    }
}
