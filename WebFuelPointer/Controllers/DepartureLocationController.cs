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
    [ProducesResponseType(statusCode:201),ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost]
    public async Task<ActionResult<CreateDepartureLocationResponse>> Post(string Search, CancellationToken cancellationToken)
    {
        List<string> DatefomatedApi = await _externalCases.PassingOnData(search: Search);
        CreateDepartureLocationRequest createDepartureLocationRequest = new CreateDepartureLocationRequest(DatefomatedApi[5], DatefomatedApi[3] + DatefomatedApi[4], DatefomatedApi[1], DatefomatedApi[2], DatefomatedApi[0], default);
        var response = await _mediator.Send(createDepartureLocationRequest);
        return Ok(response);
    }
    [ProducesResponseType(StatusCodes.Status202Accepted),ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<ActionResult<UpdateDeparureLocationResponse>> Put(string search,int IdDestination, CancellationToken cancellationToken)
    {
        List<string> DatefomatedApi = await _externalCases.PassingOnData(search: search);
        UpdateDepartureLocationRequest updateDeparureLocationResquest = new UpdateDepartureLocationRequest(IdDestination, DatefomatedApi[5], DatefomatedApi[3] + DatefomatedApi[4], DatefomatedApi[1], DatefomatedApi[2], DatefomatedApi[0], default);
        var response = await _mediator.Send(updateDeparureLocationResquest, cancellationToken);
        return Ok(response);
    }
    [ProducesResponseType(StatusCodes.Status202Accepted),ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpGet]
    public async Task<ActionResult<ReadDepartureLocationResponse>> Get(ReadDepartureLocationRequest readDepartureLocationRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(readDepartureLocationRequest);
        if (response is null) { return BadRequest(response); }
        return Ok(response);
    }
    [ProducesResponseType(StatusCodes.Status200OK),ProducesResponseType(StatusCodes.Status403Forbidden)]
    [HttpDelete]
    public async Task<ActionResult<DeleteDepartureLocationResponse>> Delete(DeleteDepartureLocationRequest deleteDepartureLocationRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(deleteDepartureLocationRequest);
        if (response is null) { return BadRequest(response); }
        return Ok(response);
    }
}
