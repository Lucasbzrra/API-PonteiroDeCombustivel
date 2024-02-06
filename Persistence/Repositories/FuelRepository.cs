using Domain.Entities;
using Domain.Interfaces;
using Persistence.DataContext;
namespace Persistence.Repositories;

public class FuelRepository : BaseRepository<Fuel>,IFuelRepository
{
    public FuelRepository(FuelPointerDbContext fuelContext) : base(fuelContext)
    {
    }
    public async Task<Fuel> GetByFuel(int id, CancellationToken cancellationToken)
    {
        return _context.Tb_Fuels.FirstOrDefault(x => x.IdFuel == id);
    }
}
