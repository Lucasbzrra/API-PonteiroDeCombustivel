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

	[HttpPost("/v1/PostFuel/")]
	public async Task<ActionResult<FuelCreateResponse>> Create(FuelCreateRequest fuelCreateRequest, CancellationToken cancellationToken )
	{

		var response=await	_mediator.Send(fuelCreateRequest,cancellationToken);
		return Ok(response);
	}
}
