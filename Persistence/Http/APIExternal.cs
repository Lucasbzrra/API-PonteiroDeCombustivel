using Domain.EntitiesExternal;
using Domain.Interfaces;

namespace Persistence.Http;

public  class APIExternal:IApiExternal
{
    private readonly HttpClient Client;
    public APIExternal(HttpClient httpClient)
    {
        Client = httpClient;

    }

    public  async Task< Finaly> ConsumeApi(string search)
    {
        try
        {
            var uri = new Uri($"https://api.opencagedata.com/geocode/v1/json?q={search}&key=e2f083917f5f45738113b8b293a96642&language=pt&pretty=1");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = Client.Send(request);
            var responseBody = response.Content.ReadAsStringAsync().Result;
            Finaly finaly = await ConvertTobeClass(responseBody);
            return finaly;
            
        }
        catch (Exception)
        {

            throw new Exception("Falha ao consumir a API");
        }

    }
    public  async Task<Finaly> ConvertTobeClass(string responseBody)
    {
        Finaly finaly =   System.Text.Json.JsonSerializer.Deserialize<Finaly>(responseBody);
        return finaly;
    }

}
