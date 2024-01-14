using Domain.Entities;

namespace Domain.Interfaces;

public interface IDepartureLocationRepository : IBaseRepository<DepartureLocation>
{
    Task<DepartureLocation> GetbyDepartureLocation(int id);
}