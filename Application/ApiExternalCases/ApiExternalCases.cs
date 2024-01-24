using Application.DepartureLocationCases.Command;
using Application.DestinationCases.Command;
using Domain.EntitiesExternal;
using Domain.Interfaces;
using System.Diagnostics.Metrics;

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
        Finaly finaly = await LocationSearch(search);
        if (finaly == default) { throw new Exception("Falha ao buscar dados da api"); }
        List<string> DatefomatedApi = await CutString(finaly.results[0].formatted);
        var CreateRequest = TypeRecor(DatefomatedApi,'a', id);
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
                 default
                    );
                return createDestination;
        }
        return default;
    }

    //static Object TypeRecord(Object Object, List<string> DatefomatedApi)
    //{
    //    return Object switch
    //    {
    //        CreateDepartureLocationRequest createDeparture => createDeparture with
    //        {
    //            Country = DatefomatedApi[5],
    //            Cep = DatefomatedApi[3] + DatefomatedApi[4],
    //            City = DatefomatedApi[1],
    //            UF = DatefomatedApi[2],
    //            ReferencePoint = DatefomatedApi[0],
    //            FuelId = default
                 
    //        },
    //        CreateDestinationRequest createDestination => createDestination with
    //        {
    //             Country = DatefomatedApi[5],
    //             Cep = DatefomatedApi[3] + DatefomatedApi[4],
    //             City = DatefomatedApi[1],
    //             UF = DatefomatedApi[2],
    //             ReferencePoint = DatefomatedApi[0],
    //            FuelIdd = default

    //        },
    //        _ => Object


    //    };
       
    //}
}
