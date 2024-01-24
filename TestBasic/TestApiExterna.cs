using Application.ApiExternalCases;
using Domain.EntitiesExternal;
using Persistence.Http;

namespace TestBasic;

public class TestApiExterna
{
    [Fact]
    public async void APiForaRetornarUmaExcecao()
    {
        HttpClient client = new HttpClient();
        APIExternal api= new APIExternal(client);
        Assert.ThrowsAsync<Exception>(() => api.ConsumeApi("Valparaiso shopping sul"));


    }
    [Fact]
    public async void APIRetornandoOsDados()
    {
        HttpClient client = new HttpClient();
        APIExternal api = new APIExternal(client);
        Finaly finaly = await api.ConsumeApi("Valparaiso shopping sul");
        Assert.NotNull(finaly);

    }

    [Fact]

    public async void TesteCases()
    {
        HttpClient client= new HttpClient();
        APIExternal aPIExternal = new APIExternal(client);
        ApiExternalCases cases = new ApiExternalCases(aPIExternal);
        //var dados= await cases.PassingOnData("valparaiso de goias Havan");
        //Assert.NotNull(dados);
    }
}