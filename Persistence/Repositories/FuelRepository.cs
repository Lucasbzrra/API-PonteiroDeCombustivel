using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;
using System.Linq;
using System.Xml.Linq;

namespace Persistence.Repositories;

public class FuelRepository : BaseRepository<Fuel>,IBaseRepository<Fuel>
{
    public FuelRepository(FuelPointerDbContext fuelContext) : base(fuelContext)
    {
    }
    public async Task<Object> CalculateTotalFuel(params object[] objects)
    {
       Object functin()
       {
            if (name is null) ;
             var name1 =_context.Tb_Fuels;
            return name1;
        }
            var query = functin()+"".Where(x => x.Vehicle.Plate.Equals(plate, StringComparison.InvariantCultureIgnoreCase))
                                    .Select(a => a.ValuePerLiter *  a.QuantityOfLiters);
        return  query.ToListAsync();
    }
    public Task<Object> CalculateAutonimiaFuel(string plate)
    {
        var query = _context.Tb_Fuels.Where(x => x.Vehicle.Plate.Equals(plate, StringComparison.InvariantCultureIgnoreCase))
                                   .Select(a => a.ValuePerLiter * a.QuantityOfLiters);
    }
}
