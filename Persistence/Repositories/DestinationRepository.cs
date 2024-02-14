using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;


namespace Persistence.Repositories;

public class DestinationRepository : BaseRepository<Destination>, IDestinationRepository
{
    public DestinationRepository(FuelPointerDbContext contex):base(contex)
    {

    }

    public async Task<Destination> GetbyDestination(int id)
    {
       return await _context.Tb_Destinations.FirstOrDefaultAsync(destination => destination.IdDestination == id);
    }
}


