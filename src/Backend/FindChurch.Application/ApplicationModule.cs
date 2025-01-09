using FindChurch.Application.Queries.ChurchQueries.GetAllChurches;
using FindChurch.Application.Queries.MinistryQueries.GetAllMinistries;
using FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServices;
using Microsoft.Extensions.DependencyInjection;

namespace FindChurch.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidation();
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<GetAllChurchesQuery>();
            config.RegisterServicesFromAssemblyContaining<GetAllMinistriesQuery>();
            config.RegisterServicesFromAssemblyContaining<GetAllWorshipServicesQuery>();
        });
        return services;
    }
    
    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        return services;
    }
}