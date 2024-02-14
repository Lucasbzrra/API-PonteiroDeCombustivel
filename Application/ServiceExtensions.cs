using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.UserCases;
using Application.Shared.Behavior;
using MediatR;
using FluentValidation;

namespace Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(assemblies: Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IToken, TokenService>();
    }

}
