using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Persistence.DataContext;

public class FuelPointerDbContext: IdentityDbContext<User>
{
    public FuelPointerDbContext(DbContextOptions<FuelPointerDbContext> opt) : base(opt)
    {

    }
    public FuelPointerDbContext() // Adicione este construtor
    {

    }

    public DbSet<Fuel> Tb_Fuels { get; set; }
    public DbSet<Vehicle> Tb_Vehicles { get; set; }
    public DbSet<Destination> Tb_Destinations { get; set; }
    public DbSet<DepartureLocation> Tb_DepartureLocations { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<User>()
            .HasMany(x => x.vehicles)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);


        modelBuilder.Entity<Fuel>()
        .HasOne(Fuel => Fuel.DepartureLocation)
        .WithOne(departure => departure.Fuel)
        .HasForeignKey<DepartureLocation>(departure => departure.FuelId);

        modelBuilder.Entity<Fuel>()
        .HasOne(fuel => fuel.Destination)
        .WithOne(departure => departure.Fuel)
        .HasForeignKey<Destination>(departure => departure.FuelId);


        modelBuilder.Entity<Vehicle>().HasIndex(vehicle => vehicle.Plate).IsUnique();
        modelBuilder.Entity<Vehicle>().HasIndex(Vehicle => Vehicle.IdVehicle).IsUnique();
        modelBuilder.Entity<Fuel>().HasIndex(fuel => fuel.IdFuel).IsUnique();
        modelBuilder.Entity<Destination>().HasIndex(Destination => Destination.IdDestination).IsUnique();
        modelBuilder.Entity<DepartureLocation>().HasIndex(DepartureLocation => DepartureLocation.IdDepartureLocation).IsUnique();

    }

}
