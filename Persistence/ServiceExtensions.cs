using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataContext;
using Persistence.Repositories;
using Persistence.Repository;


namespace Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<FuelPointerDbContext>(opt => opt.UseSqlServer(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
    }
}
