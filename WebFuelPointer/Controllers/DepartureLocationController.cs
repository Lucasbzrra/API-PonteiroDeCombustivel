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
    private Mediator _mediator;
    private ApiExternalCases _externalCases;
    public DepartureLocationController(Mediator mediator, ApiExternalCases externalCases)
    {
        _mediator = mediator;
        _externalCases = externalCases;
    }
    [HttpPost]
    public async Task<ActionResult<CreateDepartureLocationResponse>> Post( CreateDepartureLocationRequest createDepartureLocationRequest ,string Search , CancellationToken cancellationToken)
    {
        var validacao= await _externalCases.LocationSearch(search: "valparaiso de goias, Havan");

        await _mediator.Send(createDepartureLocationRequest);
        return Ok(createDepartureLocationRequest);
    }
    [HttpGet]
    public async Task<ActionResult<ReadDepartureLocationResponse>> Get(ReadDepartureLocationRequest readDepartureLocationRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(readDepartureLocationRequest);
        if (response is null) { return BadRequest(response); }
        return Ok(response);
    }
    [HttpDelete]
    public async Task<ActionResult<DeleteDepartureLocationResponse>> Delete(DeleteDepartureLocationRequest deleteDepartureLocationRequest, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(deleteDepartureLocationRequest);
        if (response is null) { return BadRequest(response); }
        return Ok(response);
    }
}
