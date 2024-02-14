using Application.Shared.Exceptions;
using Domain.EntitiesExternal;
using Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace Application.ApiExternalCases;

public class ApiExternalCases
{
    private readonly IApiExternal _APIExternal;
    public ApiExternalCases(IApiExternal aPIExternal)
	{ 
        _APIExternal = aPIExternal;
	}
    public async Task<Finaly> PassingOnData(string search)
    {
        Finaly finaly = await LocationSearch(search);
        if (finaly == default) { throw new ConnectionApiException("Falha ao retornar dados da API"); }
        return finaly;
    }
    public async Task<object> MapeandoDados(Finaly finaly,Guid idfuel,string ? typeobject,Guid ? Idlocal)
    {
        ILocalFactory localFactory = new ConcreteFactory();
        var ObjectLocal = localFactory.CreateObject(finaly, typeobject, idfuel, Idlocal);
        return ObjectLocal;

    }
    private async Task<Finaly> LocationSearch(string search)
    {
        Finaly finaly = await _APIExternal.ConsumeApi(search);
        if (finaly is null) { return default; }
        return finaly;
    }
}
