using IdentityApi.Domain.Entities;

namespace IdentityApi.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> FindAsync(object userId, CancellationToken cancellationToken = default);
    Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default);
    Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default);
    Task<bool> VerifyPasswordAsync(User user, string password, CancellationToken cancellationToken = default);
}