using Application.ApiExternalCases;
using Application.DestinationCases.Command;
using Application.DestinationCases.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebFuelPointer.Controllers;


[ApiController]
[Route("/Controller")]
public class DestinationController:ControllerBase
{
	private readonly Mediator _mediator;
	private readonly ApiExternalCases _apiExternalCases;
	public DestinationController(Mediator mediator, ApiExternalCases apiExternalCases)
	{
		_mediator = mediator;
		_apiExternalCases = apiExternalCases;
	}
	[HttpPost("/Post/Destination")]
	public async Task<ActionResult<CreateDestinationResponse>> post(string search, CancellationToken cancellationToken)
	{
		//Corrigir a situação do Guid Passado no Casos de Uso Exteno
		CreateDestinationRequest createDestinationRequest= await _apiExternalCases.PassingOnData(search);
        var responseDestination=await _mediator.Send(createDestinationRequest);
		return Ok(responseDestination);
	}

}
