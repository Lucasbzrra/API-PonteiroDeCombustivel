using Application.ApiExternalCases;
using Application.DestinationCases.Command;
using Application.DestinationCases.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebFuelPointer.Controllers;


[ApiController]
[Route("/Controller")]
public class DestinationController:ControllerBase
{
	private readonly IMediator _mediator;
	private readonly ApiExternalCases _apiExternalCases;
	public DestinationController(IMediator mediator, ApiExternalCases apiExternalCases)
	{
		_mediator = mediator;
		_apiExternalCases = apiExternalCases;
	}

    [ProducesResponseType(statusCode: 201), ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost("/Post/Destination/{search}")]

    public async Task<ActionResult<CreateDestinationResponse>> post(Guid id,string search, CancellationToken cancellationToken)
    {
        var createDestinationRequest = await _apiExternalCases.PassingOnData(search, id);
        var responseDestination = await _mediator.Send(createDestinationRequest, cancellationToken);
        return Ok(responseDestination);
    }

    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("/Get/Destination/{id}")]
    
    public async Task<ActionResult<ReadDestinationResponse>> get(ReadDestinationResquet readDestinationResquet, CancellationToken cancellationToken)
    {
        var responseDestination = await _mediator.Send(readDestinationResquet, cancellationToken); 
        return Ok(responseDestination);
    }

    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("/Put/Destination/{id}")]

    public async Task<ActionResult<UpdateDestinationResponse>> Put(Guid id,string search,  CancellationToken cancellationToken)
    {
        var updateDestinationRequest = await _apiExternalCases.PassingOnData(search,id);
        var responseDestination = await _mediator.Send(updateDestinationRequest, cancellationToken);
        return Ok(responseDestination);
    }

    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete("/Delete/Destination/{id}")]
    
    public async Task<ActionResult<DeletDestinationResponse>> Delete(DeletDestinationRequest deletDestinationRequest, CancellationToken cancellationToken)
    {
        var responseDestianiton = await _mediator.Send(deletDestinationRequest);
        return Ok(responseDestianiton);
    }

}
