using FindChurch.Core.Repositories;
using FindChurch.Infrastructure.Persistence;
using FindChurch.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindChurch.Infrastructure;

public static class InfrastructureModule
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);
        return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FindChurchCS");
        services.AddDbContext<FindChurchDbContext>(options =>
            options.UseNpgsql(connectionString, npgsqlOptions =>
                npgsqlOptions.UseNetTopologySuite()));
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChurchRepository, ChurchRepository>();
        services.AddScoped<IMinistryRepository, MinistryRepository>();
        services.AddScoped<IWorshipRepository, WorshipRepository>();
        return services;
    }
    
}