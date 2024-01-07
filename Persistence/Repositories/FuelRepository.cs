using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class FuelRepository : BaseRepository<Fuel>,IBaseRepository<Fuel>
{
    public FuelRepository(FuelPointerDbContext fuelContext) : base(fuelContext)
    {
    }
    public async Task<Object> Calculate(string plate, string? SaberAutonomia)
    {
        //from a in _context.Tb_Fuels
        //join b in _context.Tb_Vehicles on a.id equals b.id
        //where b.Plate.Equals(plate, StringComparison.InvariantCultureIgnoreCase)
        //select a.QuantityOfLiters * b.KmPerLiter;
        string function()
        {
            if (SaberAutonomia != null)
            {
              
                string colunaValuePerLiter = "ValuePerLiter";
                return colunaValuePerLiter;
            }
            string colunaKmPerliter = "KmPerLiter";
            return colunaKmPerliter;
        }
        var coluna = function();

        var query = _context.Tb_Fuels.FromSqlRaw($"select QuantityOfLiters * @coluna  from _context.Tb_Fuels  join _context.Tb_Vehicles on _context.Tb_Fuels.plate=_context.Tb_Vehicles.plate where plate=_context.Tb_Fuels.plate");

        return query.ToListAsync();
    }
    public async Task<Object> CalculateTotalFuel(string plate, string table)
    {
        //var query = _context.Tb_Fuels.Where(x => x.Vehicle.Plate.Equals(plate, StringComparison.InvariantCultureIgnoreCase))
        //                            .Select(a => a.ValuePerLiter * a.QuantityOfLiters);
        var result = Calculate(plate, table);
        return result;
    }
    
}
