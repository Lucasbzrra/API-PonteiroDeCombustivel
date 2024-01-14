using Domain.Entities;


namespace Domain.Interfaces;

public interface IDestinationRepository:IBaseRepository<Destination>
{
    Task<Destination> GetbyDestination(int id);
}
