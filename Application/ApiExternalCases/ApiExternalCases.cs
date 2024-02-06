using Application.DepartureLocationCases.Command;
using Application.DestinationCases.Command;
using Domain.EntitiesExternal;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.ApiExternalCases;

public class ApiExternalCases
{
    private readonly IApiExternal _APIExternal;
    public ApiExternalCases(IApiExternal aPIExternal)
	{
        _APIExternal = aPIExternal;
	}
    public async Task<Object> PassingOnData(string search,Guid id)
    {
        List<string> DateFormatedApi= new List<string>();

        Finaly finaly = await LocationSearch(search);
        if (finaly == default) { throw new Exception("Falha ao buscar dados da api"); }
        var result = await CutString(finaly.results[0].formatted);
        DateFormatedApi = result;
        DateFormatedApi.Add(finaly.results[0].geometry.lat.ToString());
        DateFormatedApi.Add(finaly.results[0].geometry.lng.ToString());
        var CreateRequest = TypeRecor(DateFormatedApi,'a', id);
        return CreateRequest;
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

    static Object TypeRecor(List<string> DatefomatedApi,char charecter, Guid id)
    {
        switch (charecter)
        {
            case 'a':
                CreateDepartureLocationRequest createDeparture = new CreateDepartureLocationRequest
                (
                 DatefomatedApi[5],
                 DatefomatedApi[3] + DatefomatedApi[4],
                 DatefomatedApi[1],
                 DatefomatedApi[2],
                 DatefomatedApi[0],
                 DatefomatedApi[7],
                 DatefomatedApi[8],
                 id
                    );
                return createDeparture;
            case 'b':
                 CreateDestinationRequest createDestination = new CreateDestinationRequest
                (
                 DatefomatedApi[5],
                 DatefomatedApi[3] + DatefomatedApi[4],
                 DatefomatedApi[1],
                 DatefomatedApi[2],
                 DatefomatedApi[0],
                 DatefomatedApi[6],
                 DatefomatedApi[7],
                 id
                    );
                return createDestination;
        }
        return default;
    }

  
}
