using Application.DestinationCases.Command;
using Application.DestinationCases.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.DestinationCases.Handler;

public class DestinationHandler : IRequestHandler<CreateDestinationRequest, CreateDestinationResponse>,
                                  IRequestHandler<ReadDestinationResquet, ReadDestinationResponse>,
                                  IRequestHandler<DeletDestinationRequest, DeletDestinationResponse>,
                                  IRequestHandler<UpdateDestinationRequest,UpdateDestinationResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDestinationRepository _destinationRepository;
    public DestinationHandler(IMapper mapper, IUnitOfWork unitOfWork, IDestinationRepository destinationRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _destinationRepository = destinationRepository;
    }

    public async Task<CreateDestinationResponse> Handle(CreateDestinationRequest request, CancellationToken cancellationToken)
    {
        var Destination = _mapper.Map<Destination>(request);
        await _destinationRepository.Create(Destination);
        await  _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateDestinationResponse>(Destination);
    }

    public async Task<ReadDestinationResponse> Handle(ReadDestinationResquet request, CancellationToken cancellationToken)
    {

        var destinationFound = await _destinationRepository.Get(request.IdDestination, cancellationToken);
        return _mapper.Map<ReadDestinationResponse>(destinationFound);
    }

    public async Task<DeletDestinationResponse> Handle(DeletDestinationRequest request, CancellationToken cancellationToken)
    {
        var destinatonFound = await _destinationRepository.Get(request.IdDestination,cancellationToken);
        if (destinatonFound is null) { return default; }
        _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<DeletDestinationResponse>(destinatonFound);

    }

   public async Task<UpdateDestinationResponse> Handle(UpdateDestinationRequest request, CancellationToken cancellationToken)
    {
        var destinatonFound = await _destinationRepository.Get(request.idDestination,cancellationToken);
        if(destinatonFound is null) { return default; }
        _mapper.Map(request, destinatonFound);
        _destinationRepository.Update(destinatonFound);
        _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<UpdateDestinationResponse>(destinatonFound);

    }
}

