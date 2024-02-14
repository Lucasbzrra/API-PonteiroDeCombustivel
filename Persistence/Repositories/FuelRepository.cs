using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
namespace Persistence.Repositories;

public class FuelRepository : BaseRepository<Fuel>,IFuelRepository
{
    public FuelRepository(FuelPointerDbContext fuelContext) : base(fuelContext)
    {
    }
    public async Task<Fuel> GetByFuel(int id, CancellationToken cancellationToken)
    {
        return await _context.Tb_Fuels.FirstOrDefaultAsync(x => x.IdFuel == id);
    }
}
