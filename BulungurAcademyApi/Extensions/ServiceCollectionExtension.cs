using BulungurAcademy.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BulungurAcademy.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDbContexts(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString=configuration.GetConnectionString("SqlServer");

        services.AddDbContextPool<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure();
            });
        });

        return services;
    }
}
