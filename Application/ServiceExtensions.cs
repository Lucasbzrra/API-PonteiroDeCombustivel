using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.UserCases;
using Persistence.DataContext;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        //
        //.AddDefaultTokenProviders();
        services.AddScoped<IToken, TokenService>();
    }

}
