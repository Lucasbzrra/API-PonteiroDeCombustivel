using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataContext;

public class FuelPointerDbContext:DbContext
{
	public FuelPointerDbContext(DbContextOptions<FuelPointerDbContext> opt):base(opt)
	{

	}
    public DbSet<Fuel> Tb_Fuels { get; set; }
    public DbSet<Vehicle> Tb_Vehicles { get; set; }
    public DbSet<Destination> Tb_Destinations { get; set; }
    public DbSet<DepartureLocation> Tb_DepartureLocations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plate).IsUnique();
        
    }
}
