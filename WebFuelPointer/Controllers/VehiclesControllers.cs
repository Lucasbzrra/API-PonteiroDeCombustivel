using Application.VehicleCases.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebFuelPointer.Controllers;

[ApiController]
[Route("/Controller")]
public class VehiclesControllers:ControllerBase
{
	private readonly IMediator _mediator;
	public VehiclesControllers(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpPost("/v1/Post")]
	[ProducesResponseType(statusCode:200),ProducesResponseType(statusCode:400)]
	public async Task<ActionResult<CreateVehicleResponseDto>> Create(CreateVehicleRequestDto createVehicleRequestDto,CancellationToken cancellationToken)
	{
		var response = await _mediator.Send(createVehicleRequestDto,cancellationToken);
		return Ok(response);
	}
}
