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
    private  DestinationController _destinationController;
	public FuelController(IMediator mediator, DestinationController destinationController)
	{
		_mediator= mediator;
        _destinationController= destinationController;
	}

    /// <summary>
    /// Cadastramento de abastecimento de veiculo
    /// </summary>
    /// <param name="fuelCreateRequest"> Dados da para criação de cadastro</param>
    /// <param name="cancellationToken"> Paramentro para fazer o cancelamento do cadastro</param>
    /// <returns></returns>
    [HttpPost("/v1/PostFuel/")]
    [ProducesResponseType(statusCode: 200)]
    public async Task<ActionResult<FuelCreateResponse>> Create(FuelCreateRequest fuelCreateRequest, CancellationToken cancellationToken)
    {

        var response = await _mediator.Send(fuelCreateRequest, cancellationToken);
        
        _destinationController.post(response.departureLocation, cancellationToken);

        return Ok(response);
    }


    [HttpGet("/v1/GetFuel/{id}")]
    [ProducesResponseType(statusCode: 200), ProducesResponseType(statusCode: 400)]
    public async Task<ActionResult<FuelReadResponse>> Get(FuelReadRequest fuelReadRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(fuelReadRequest, cancellationToken);
        if (response is null) { return BadRequest(response); }
        return Ok(response);

    }
    [HttpDelete("/v1/DeletFuel/{id}")]
    public async Task<ActionResult<FuelDeleteResponse>> Delete(FuelDeleteRequest fuelDeleteRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(fuelDeleteRequest, cancellationToken);
        if (response is null) { return BadRequest(response); }
        return Accepted(response);
    }
}
