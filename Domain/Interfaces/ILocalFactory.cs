using Domain.EntitiesExternal;

namespace Domain.Interfaces;

public interface ILocalFactory
{
    Object CreateObject(Finaly finaly, string? typeobject, Guid idFuel,Guid ? idlocal);
}
