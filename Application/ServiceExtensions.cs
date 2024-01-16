using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Http;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //services.AddScoped<IApiExternal, APIExternal>();

    }

}
