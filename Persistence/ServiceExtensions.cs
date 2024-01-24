using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataContext;
using Microsoft.AspNetCore.Identity;
using Persistence.Http;
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
        services.AddScoped<IFuelRepository,FuelRepository>();
        services.AddScoped<IDestinationRepository, DestinationRepository>();
        services.AddScoped<IDepartureLocationRepository, DepartureLocationRepository>();
        //  services.AddScoped<IApiExternal>();
        services.AddScoped<IApiExternal, APIExternal>();
        services.AddScoped<HttpClient>();
    }
}
