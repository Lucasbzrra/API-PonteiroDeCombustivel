using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Http;
using Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //services.AddScoped<IDestinationRepository, DestinationRepository>();
        //services.AddScoped<IDepartureLocationRepository, DepartureLocationRepository>();
        //services.AddScoped<IApiExternal, APIExternal>();
        //services.AddScoped<HttpClient>();
    }
}
