using IdentityApi.Domain.Entities;
using IdentityApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Infrastructure.Repositories;

class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;
    public async Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AsNoTracking().AnyAsync(e => e.Email == email, cancellationToken);
    }

    public async Task<User?> FindAsync(object userId, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FindAsync([userId], cancellationToken);
    }

    public async Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(e => e.Email == email, cancellationToken);
    }

    public async Task<User?> FindByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Users.FirstOrDefaultAsync(e => e.Username == username, cancellationToken);
    }

    public async Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.Users.AsNoTracking().AnyAsync(e => e.Username == username, cancellationToken);
    }

    public Task<bool> VerifyPasswordAsync(User user, string password, CancellationToken cancellationToken = default)
    {
        var hash = _context.Users.Entry(user).Property<string?>("PasswordHash").CurrentValue;
        var isCorrect = !string.IsNullOrEmpty(password) && hash is not null && BCrypt.Net.BCrypt.Verify(password, hash);

        return Task.FromResult(isCorrect);
    }
}