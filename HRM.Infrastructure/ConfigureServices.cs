using HRM.Domain.Interfaces;
using HRM.Domain.Interfaces.Common;
using HRM.Infrastructure.Repositories;
using HRM.Infrastructure.Repositories.Common;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}