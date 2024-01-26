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
    //[HttpGet("/Get/User/{}")]
    //public async Task<ActionResult<GetAllLoginUserResponse>> Get(GetAllReadloginRequest readloginRequest,CancellationToken cancellationToken)
    //{
    //    _mediator.Send();
    //}

    //[HttpPost("/Post/User")]
    //public async Task<ActionResult<CreateLoginResponse>> Post(CreateLoginRequest createLoginRequest, CancellationToken cancellation)
    //{
    //   var response= _mediator.Send(createLoginRequest, cancellation);
    //    return CreatedAtAction(nameof(Get), new { name = createLoginRequest.Email }, response);
    //}
    //[HttpDelete("/Delete/User/{id}")]
    //public async Task<ActionResult<DeleteloginResponse>> Delete(DeleteloginResponseRequest deleteloginResponseRequest, CancellationToken cancellationToken)
    //{

    //}
}