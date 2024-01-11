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


        modelBuilder.Entity<Fuel>()
        .HasOne(Fuel => Fuel.departureLocation)
        .WithOne(departure => departure.Fuel)
        .HasForeignKey<DepartureLocation>(departure => departure.FuelId);

        modelBuilder.Entity<Fuel>()
        .HasOne(fuel => fuel.destination)
        .WithOne(departure => departure.Fuel)
        .HasForeignKey<Destination>(departure => departure.FuelId);

        modelBuilder.Entity<Vehicle>().HasIndex(vehicle => vehicle.Plate).IsUnique();
        modelBuilder.Entity<Vehicle>().HasIndex(Vehicle=> Vehicle.idVehicle).IsUnique();
        modelBuilder.Entity<Fuel>().HasIndex(fuel => fuel.IdFuel).IsUnique();
        modelBuilder.Entity<Destination>().HasIndex(Destination=>Destination.IdDestination).IsUnique();
        modelBuilder.Entity<DepartureLocation>().HasIndex(DepartureLocation => DepartureLocation.IdDepartureLocation).IsUnique();


    }
}
