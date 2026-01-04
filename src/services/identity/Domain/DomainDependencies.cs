using IdentityApi.Domain.Services;

namespace IdentityApi.Domain;

public static class DomainDependencies
{
    public static void AddAll(IServiceCollection services)
    {
        services.AddScoped<AuthService>();
    }
}