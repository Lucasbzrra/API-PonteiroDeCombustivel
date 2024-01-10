using Domain.Entities;

namespace Domain.Interfaces;

public interface IFuelRepository : IBaseRepository<Fuel>
{
    Task<Fuel> GetByFuel(int id, CancellationToken cancellationToken);
}
