using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(FuelPointerDbContext context) : base(context) { }


    public async Task<Vehicle> GetByVehicle(string plate, CancellationToken cancellationToken)
    {
        return await _context.Tb_Vehicles.FirstOrDefaultAsync(x=>x.Plate== plate,cancellationToken);
    }
}
