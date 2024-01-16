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

    /// <summary>
    /// Cadastramento de abastecimento de veiculo
    /// </summary>
    /// <param name="fuelCreateRequest"> Dados da para criação de cadastro</param>
    /// <param name="cancellationToken"> Paramentro para fazer o cancelamento do cadastro</param>
    /// <returns></returns>
    [HttpPost("/v1/PostFuel/")]
    [ProducesResponseType(statusCode: 201), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FuelCreateResponse>> Create(FuelCreateRequest fuelCreateRequest, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(fuelCreateRequest, cancellationToken);
        
        return Ok(response);
    }


    [HttpGet("/v1/GetFuel/")]
    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<FuelReadResponse>> Get(FuelReadRequest fuelReadRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(fuelReadRequest, cancellationToken);
        if (response is null) { return Unauthorized(response); }
        return Accepted(response);

    }
    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("/v1/Put/Fuel")]
    public async Task<ActionResult<FuelUpdateResponse>> put(FuelUpdateRequest fuelUpdateRequest, CancellationToken cancellationToken)
    {
        var response=await _mediator.Send(fuelUpdateRequest, cancellationToken);
        if (response is null) { return NoContent(); }
        return Accepted(response);
    }

    [HttpDelete("/v1/DeletFuel/")]
    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FuelDeleteResponse>> Delete(FuelDeleteRequest fuelDeleteRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(fuelDeleteRequest, cancellationToken);
        if (response is null) { return NotFound() ; }
        return Ok(response);
    }
}
