using Application.UserCases;
using Application.UserCases.Command;
using Application.UserCases.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebFuelPointer.Controllers;
[ApiController]
[Route("/Controller")]

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Post/User")]
    public async Task<ActionResult<CreateLoginResponse>> Post(CreateLoginRequest createLoginRequest, CancellationToken cancellation)
    {
        var response = await _mediator.Send(createLoginRequest, cancellation);
        return CreatedAtAction(nameof(Get), new { name = createLoginRequest.Email }, response);
    }

    [HttpGet("/Get/User/")]
    public async Task<ActionResult<ReadLoginResponse>> Get(ReadLoginRequest readloginRequest, CancellationToken cancellationToken)
    {
        var response= await _mediator.Send(readloginRequest,cancellationToken);
        return Ok(response);
    }

    [HttpPut("/Update/User")]
    public async Task<ActionResult<UpdateLoginResponse>> Put(UpdateLoginRequest updateLoginRequest,CancellationToken cancellationToken)
    {
        var response =await _mediator.Send(updateLoginRequest, cancellationToken);
        return Ok(response);
    }
    
    [HttpDelete("/Delete/User/")]
    public async Task<ActionResult<DeleteLoginResponse>> Delete(DeleteLoginRequest deleteloginResponseRequest, CancellationToken cancellationToken)
    {
        var response= await _mediator.Send(deleteloginResponseRequest, cancellationToken);
        return Ok(response);
    }
    
}