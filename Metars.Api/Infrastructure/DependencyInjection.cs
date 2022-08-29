using Metars.Api.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Metars.Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        Action<DbContextOptionsBuilder> optionsAction = opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString(name: "ApplicationDbContext"),
                b =>
                {
                    b.EnableRetryOnFailure(3, TimeSpan.FromSeconds(3), errorCodesToAdd: null);
                });
        };

        services.AddDbContext<ApplicationDbContext>(optionsAction,
            contextLifetime: ServiceLifetime.Scoped,
            optionsLifetime: ServiceLifetime.Singleton);

        services.AddDbContextFactory<ApplicationDbContext>(optionsAction);

        return services;
    }
}