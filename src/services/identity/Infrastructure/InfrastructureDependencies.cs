using AppCommon.Repositories;
using IdentityApi.Domain.Repositories;
using IdentityApi.Infrastructure.Repositories;
using IdentityApi.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Infrastructure;

public static class InfrastructureDependencies
{
    public static void AddAll(IServiceCollection services)
    {
        services.AddDbContext<DataContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("IdentityDB");
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public static async Task MigrateDatabaseAsync(this IHost app, CancellationToken cancellationToken = default)
    {
        using var scope = app.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync(cancellationToken);
        await new UserSeed(context).SeedAsync(1000, cancellationToken);
    }
}