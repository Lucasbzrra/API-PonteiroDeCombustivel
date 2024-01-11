using Domain.Entities;
using Domain.Interfaces;
using Persistence.DataContext;


namespace Persistence.Repositories;

public class DestinationRepository : BaseRepository<Destination>, IDestinationRepository
{
    public DestinationRepository(FuelPointerDbContext contex):base(contex)
    {

    }

    public async Task<Destination> GetbyDestination(int id)
    {
       return _context.Tb_Destinations.FirstOrDefault(destination => destination.IdDestination==id);
    }
}


