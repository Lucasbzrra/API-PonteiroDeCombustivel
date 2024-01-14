
using Domain.EntitiesExternal;

namespace Domain.Interfaces;

public interface IApiExternal
{
    Task<Finaly> ConsumeApi(string serach);
    Task<Finaly> ConvertTobeClass(string responseBody);
}
