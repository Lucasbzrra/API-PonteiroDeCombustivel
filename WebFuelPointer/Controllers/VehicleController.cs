﻿using Application.VehicleCases.CreateVehicle.Command;
using Application.VehicleCases.CreateVehicle.Queries;
using Application.VehicleCases.CreateVehicle.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebFuelPointer.Controllers;

[ApiController]
[Route("/Controller")]
public class VehicleController:ControllerBase
{
	private readonly IMediator _mediator;
	public VehicleController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost("/Post/Vehicle/")]
    [ProducesResponseType(statusCode:201),ProducesResponseType(statusCode:400)]

	public async Task<ActionResult<CreateVehicleResponse>> Create([FromBody]CreateVehicleRequest createVehicleRequestDto,CancellationToken cancellationToken)
	{
		var response = await _mediator.Send(createVehicleRequestDto,cancellationToken);
		return Ok(response);
	}

    [HttpGet("/Get/Vehicle")]
    [ProducesResponseType(statusCode:202),ProducesResponseType(statusCode:401)]

	public async Task<ActionResult<ReadVehicleResponse>> Get( ReadVehicleRequest id , CancellationToken cancellationToken)
	{
		var response= await _mediator.Send(id, cancellationToken );
		return Accepted(response);
	}

    [HttpPut("/Put/Vehicle/{id}")]
    [ProducesResponseType(statusCode: 202), ProducesResponseType(statusCode: 401)]

    public async Task<ActionResult<UpdateVehicleResponse>> Update(UpdateVehicleReques dto, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(dto, cancellationToken);
        if (response is null) { return NoContent(); }
        return Accepted(response);
    }

    [HttpDelete("/Delete/Vehicle/{id}")]
    [ProducesResponseType(statusCode: 202), ProducesResponseType(statusCode: 401)]

    public async Task<ActionResult<ReadVehicleResponse>> Delete(DeleteVehicleRequest dto, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(dto, cancellationToken);
        return Accepted(response);
    }

  
}
