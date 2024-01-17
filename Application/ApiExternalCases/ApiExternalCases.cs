using Application.DepartureLocationCases.Command;
using Application.DestinationCases.Command;
using Domain.EntitiesExternal;
using Domain.Interfaces;
namespace Application.ApiExternalCases;

public class ApiExternalCases
{
    private readonly IApiExternal _APIExternal;
    public ApiExternalCases(IApiExternal aPIExternal)
	{
        _APIExternal = aPIExternal;
	}
    public async Task<Object> PassingOnData(string search, int ? id)
    {
        Finaly finaly = await LocationSearch(search);
        if (finaly == default) { throw new Exception("Falha ao buscar dados da api"); }
        var DatefomatedApi = await CutString(finaly.results[0].formatted);

        if (id == default) 
        {
           
            CreateDepartureLocationRequest createDepartureLocationRequest = new CreateDepartureLocationRequest(
                DatefomatedApi[5], 
                DatefomatedApi[3] + DatefomatedApi[4], 
                DatefomatedApi[1], 
                DatefomatedApi[2], 
                DatefomatedApi[0], 
                default
                );
            return createDepartureLocationRequest;
        }

        return 
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

    private async Task<Object> TypeRecord()
    {
        if()
    }

}
