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
    public async Task<ActionResult<CreateDestinationResponse>> post( string search, CancellationToken cancellationToken)
    {
        List<string> DatefomatedApi = await _apiExternalCases.PassingOnData(search);
        CreateDestinationRequest createDestinationRequest = new CreateDestinationRequest(DatefomatedApi[5], DatefomatedApi[3] + DatefomatedApi[4], DatefomatedApi[1], DatefomatedApi[2], DatefomatedApi[0], default);
        var responseDestination = await _mediator.Send(createDestinationRequest);
        return Ok(responseDestination);
    }
    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("/Get/Destination/{id}")]
    public async Task<ActionResult<ReadDestinationResponse>> get(ReadDestinationResquet readDestinationResquet, CancellationToken cancellationToken)
    {
        var responseDestination = await _mediator.Send(readDestinationResquet, cancellationToken); return Ok(responseDestination);

    }
    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("/Update/Destination/{id}")]
    public async Task<ActionResult<UpdateDestinationResponse>> Put(string search,int IdDestination, CancellationToken cancellationToken)
    {
        List<string> DateFormatedApi = await _apiExternalCases.PassingOnData(search);
        UpdateDestinationRequest updateDestinationRequest = new UpdateDestinationRequest(IdDestination, DateFormatedApi[5], DateFormatedApi[3] + DateFormatedApi[4], DateFormatedApi[1], DateFormatedApi[2], DateFormatedApi[0], default);
        var responseDestination = await _mediator.Send(updateDestinationRequest, cancellationToken); return Ok(responseDestination);
    }
    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete("/Delete/Destination/{id}")]
    public async Task<ActionResult<DeletDestinationResponse>> Delete(DeletDestinationRequest deletDestinationRequest, CancellationToken cancellationToken)
    {
        var responseDestianiton = await _mediator.Send(deletDestinationRequest);
        return Ok(responseDestianiton);
    }

}
