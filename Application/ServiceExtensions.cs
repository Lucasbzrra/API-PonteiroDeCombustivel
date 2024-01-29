using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.UserCases;


namespace Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //services.AddIdentity<Domain.Entities.User, IdentityRole>()
        //
        //.AddDefaultTokenProviders();
        services.AddScoped<IToken, TokenService>();
    }

}
