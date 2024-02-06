using Application.ApiExternalCases;
using Application.DepartureLocationCases.Command;
using Application.DepartureLocationCases.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebFuelPointer.Controllers;

[ApiController]
[Route("/Controller")]
public class DepartureLocationController : ControllerBase
{
    private IMediator _mediator;
    private ApiExternalCases _externalCases;
    public DepartureLocationController(IMediator mediator, ApiExternalCases externalCases)
    {
        _mediator = mediator;
        _externalCases = externalCases;
    }

    [ProducesResponseType(statusCode: 201), ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost("/Post/DepartureLocation/{search}/{id}")]

    public async Task<ActionResult<CreateDepartureLocationResponse>> Post(Guid id , string Search, CancellationToken cancellationToken)
    { 
        var createDepartureLocationRequest = await _externalCases.PassingOnData(Search,id);
        var response = await _mediator.Send(createDepartureLocationRequest, cancellationToken);
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet("/Get/DepartureLocation/{id}")]

    public async Task<ActionResult<ReadDepartureLocationResponse>> Get(ReadDepartureLocationRequest readDepartureLocationRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(readDepartureLocationRequest,cancellationToken);
        if (response is null) { return BadRequest(response); }
        return Ok(response);
    }

    [ProducesResponseType(StatusCodes.Status202Accepted), ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("/Put/DepartureLocation/{id}/{search}")]

    public async Task<ActionResult<UpdateDeparureLocationResponse>> Put(Guid id,string search,  CancellationToken cancellationToken)
    {
        var updateDeparureLocationResquest = await _externalCases.PassingOnData(search, id);
        var response = await _mediator.Send(updateDeparureLocationResquest, cancellationToken);
        return Ok(response);
    }


    [ProducesResponseType(StatusCodes.Status200OK),ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete("/Delete/DepartureLocation/{id}")]
    
    public async Task<ActionResult<DeleteDepartureLocationResponse>> Delete(DeleteDepartureLocationRequest deleteDepartureLocationRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(deleteDepartureLocationRequest, cancellationToken);
        if (response is null) { return BadRequest(response); }
        return Ok(response);
    }
}
