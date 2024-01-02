using Domain.Entities;

namespace Domain.Interfaces;

public interface IVehicleRepository:IBaseRepository<Vehicle>
{
    Task<Vehicle> GetByVehicle(string plate, CancellationToken cancellationToken);
}
