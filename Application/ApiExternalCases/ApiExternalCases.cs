using Application.DestinationCases.Command;
using Domain.EntitiesExternal;
using Domain.Interfaces;
namespace Application.ApiExternalCases;

public class ApiExternalCases
{
    private IApiExternal _APIExternal;
    public ApiExternalCases(IApiExternal aPIExternal)
	{
        _APIExternal = aPIExternal;
	}
    public async Task<List<String>> PassingOnData(string search)
    {
        Finaly finaly = await LocationSearch(search);
        if (finaly == default) { throw new Exception("Falha ao buscar dados da api"); }
        var DatefomatedApi = await CutString(finaly.results[0].formatted);
        return DatefomatedApi;

    }

    private async Task<Finaly> LocationSearch(string search)
    {
        Finaly finaly = await _APIExternal.ConsumeApi(search);
        if (finaly is null) { return default; }
        return finaly;
    }

    private async Task<List<string>> CutString(string APIdata)
    {
        string[] Dates = APIdata.Split(',', '-');
        return Dates.ToList();
    }

}
