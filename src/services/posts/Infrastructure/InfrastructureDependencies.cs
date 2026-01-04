using PostsApi.Domain.Repositories;
using PostsApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AppCommon.Repositories;

namespace PostsApi.Infrastructure;

public static class InfrastructureDependecies
{
    public static void AddAll(IServiceCollection services)
    {
        services.AddDbContext<DataContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("PostsDB");
            options.UseNpgsql(connectionString);
        });

        services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IPostRepository, PostRepository>()
            .AddScoped<IPostLikeRepository, PostLikeRepository>();
    }
}