using Application.FuelCases.Command;
using Application.FuelCases.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;


namespace Application.FuelCases.Handlers;

public class FuelHandler:IRequestHandler<FuelCreateRequest,FuelCreateResponse>,
						 IRequestHandler<FuelDeleteRequest,FuelDeleteResponse>,
                         IRequestHandler<FuelReadRequest, FuelReadResponse>,
                         IRequestHandler<FuelUpdateRequest, FuelUpdateResponse>
{
	private readonly IFuelRepository _FuelRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	public FuelHandler(IFuelRepository FuelRepository, IUnitOfWork unitOfWork, IMapper mapper)
	{
        _FuelRepository = FuelRepository;
        _unitOfWork= unitOfWork;
        _mapper= mapper;

	}

    public async Task<FuelCreateResponse> Handle(FuelCreateRequest request, CancellationToken cancellationToken)
    {
        Fuel fuel=  _mapper.Map<Fuel>(request);
        _FuelRepository.Create(fuel);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<FuelCreateResponse>(fuel);

    }

    public async Task<FuelDeleteResponse> Handle(FuelDeleteRequest request, CancellationToken cancellationToken)
    {
        var FuelFound = await _FuelRepository.Get(request.id, cancellationToken);
        if (FuelFound == null) { return default; }
        _FuelRepository.Delete(FuelFound);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<FuelDeleteResponse>(FuelFound) ;

    }

    public async   Task<FuelReadResponse> Handle(FuelReadRequest request, CancellationToken cancellationToken)
    {
        var FuelFound = await _FuelRepository.Get(request.id, cancellationToken);

        return _mapper.Map<FuelReadResponse>(FuelFound);
    }

    public async Task<FuelUpdateResponse> Handle(FuelUpdateRequest request, CancellationToken cancellationToken)
    {
        var FuelFound = await _FuelRepository.GetByFuel(request.IdFuel, cancellationToken);
        if (FuelFound is null) { return default; }
        _mapper.Map(request, FuelFound);
        _FuelRepository.Update(FuelFound);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<FuelUpdateResponse>(FuelFound);
    }
}
