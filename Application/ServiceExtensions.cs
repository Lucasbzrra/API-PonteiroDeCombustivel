using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
       // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); <== Se caso eu fosse utilizar biblioteca Fluent Validation
    }
}
