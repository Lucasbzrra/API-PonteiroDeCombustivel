using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;


namespace Persistence.Repositories;

public class DepartureLocationRepository : BaseRepository<DepartureLocation>, IDepartureLocationRepository
{
    public DepartureLocationRepository(FuelPointerDbContext context) : base(context)
    {

    }

    public async Task<DepartureLocation> GetbyDepartureLocation(int id)
    {
        return await  _context.Tb_DepartureLocations.FirstOrDefaultAsync(departure => departure.IdDepartureLocation == id);
    }

}
