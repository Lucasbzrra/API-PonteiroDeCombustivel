using Domain.Entities;
using Domain.Interfaces;
using Persistence.DataContext;


namespace Persistence.Repositories;

public class DepartureLocationRepository : BaseRepository<DepartureLocation>, IDepartureLocationRepository
{
    public DepartureLocationRepository(FuelPointerDbContext context) : base(context)
    {

    }

    public async Task<DepartureLocation> GetbyDepartureLocation(int id)
    {
        return _context.Tb_DepartureLocations.FirstOrDefault(departure => departure.IdDepartureLocation == id);
    }

}
