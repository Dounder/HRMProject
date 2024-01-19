using FluentValidation;
using HRM.Application.Common.Behaviors;
using HRM.Application.UseCases.Auth.Services;
using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Interfaces.Auth;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConfigureServices));

        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        });

        services.AddScoped<UserService>();
        services.AddScoped<RoleService>();
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}