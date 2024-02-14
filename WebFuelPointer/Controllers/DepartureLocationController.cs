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
    [HttpPost("/Post/DepartureLocation/{search}/{idfuel}")]

    public async Task<ActionResult<CreateDepartureLocationResponse>> Post(Guid idfuel , string Search, CancellationToken cancellationToken)
    {
        var result = await _externalCases.PassingOnData(Search);
        var createDepartureLocationRequest  = await _externalCases.MapeandoDados(result, idfuel, null,null);
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
    [HttpPut("/Put/DepartureLocation/{idfuel}/{search}")]

    public async Task<ActionResult<UpdateDeparureLocationResponse>> Put(Guid idfuel, Guid idlocal,string search,  CancellationToken cancellationToken)
    {
        var result = await _externalCases.PassingOnData(search);
        var UpdateDepartureLocationRequest = await _externalCases.MapeandoDados(result, idfuel, "UpdateDeparture", idlocal);
        var response = await _mediator.Send(UpdateDepartureLocationRequest, cancellationToken);
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
