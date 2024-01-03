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
	[ProducesResponseType(statusCode:201),ProducesResponseType(statusCode:400)]
	public async Task<ActionResult<ReadVehicleResponseDto>> Create(CreateVehicleRequestDto createVehicleRequestDto,CancellationToken cancellationToken)
	{
		var response = await _mediator.Send(createVehicleRequestDto,cancellationToken);
		return Ok(response);
	}
	[HttpGet("/v1/GetVehicle/")]
	[ProducesResponseType(statusCode:202),ProducesResponseType(statusCode:401)]
	public async Task<ActionResult<ReadVehicleResponseDto>> Get( ReadVehicleRequestDto id , CancellationToken cancellationToken)
	{
		var response= await _mediator.Send(id, cancellationToken );
		return Accepted(response);
	}
}
