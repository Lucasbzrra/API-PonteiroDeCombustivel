using Application.FuelCases.Command;
using Application.FuelCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebFuelPointer.Controllers;

[ApiController]
[Route("/Controller")]
public class FuelController:ControllerBase
{
	private readonly IMediator _mediator;
	public FuelController(IMediator mediator)
	{
		_mediator= mediator;
	}


    [ProducesResponseType(statusCode: 201), ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost("/Post/Fuel/")]
   
    public async Task<ActionResult<FuelCreateResponse>> Create(FuelCreateRequest fuelCreateRequest, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(fuelCreateRequest, cancellationToken);
        
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("/Get/Fuel/{id}")]
    
    public async Task<ActionResult<FuelReadResponse>> Get(FuelReadRequest fuelReadRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(fuelReadRequest, cancellationToken);
        if (response is null) { return Unauthorized(response); }
        return Accepted(response);

    }

    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("/Put/Fuel/{id}")]

    public async Task<ActionResult<FuelUpdateResponse>> put(FuelUpdateRequest fuelUpdateRequest, CancellationToken cancellationToken)
    {
        var response=await _mediator.Send(fuelUpdateRequest, cancellationToken);
        if (response is null) { return NoContent(); }
        return Accepted(response);
    }

    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("/Delete/Fuel/{id}")]
    
    public async Task<ActionResult<FuelDeleteResponse>> Delete(FuelDeleteRequest fuelDeleteRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(fuelDeleteRequest, cancellationToken);
        if (response is null) { return NotFound() ; }
        return Ok(response);
    }
}
