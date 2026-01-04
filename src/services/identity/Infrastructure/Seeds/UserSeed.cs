using Bogus;
using IdentityApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Infrastructure.Seeds;

internal class UserSeed(DataContext context)
{
    private readonly DataContext _context = context;
    private const int _minCount = 1;
    private const int _maxCount = 10_000;

    public async Task SeedAsync(int count = 1000, CancellationToken cancellationToken = default)
    {
        if (await _context.Users.AsNoTracking().AnyAsync(cancellationToken)) return;

        count = count < _minCount ?
            _minCount :
             count > _maxCount ? _maxCount : count;

        var users = new Faker<User>()
            .CustomInstantiator(f =>
            {
                return new User(
                    f.Person.UserName,
                    f.Person.Email,
                    f.Person.FullName,
                    f.Person.Phone
                );
            })
            .Generate(count);
        var passwordHash = BCrypt.Net.BCrypt.HashPassword("123");
        await _context.AddRangeAsync(users, cancellationToken);
        foreach(var user in users)
        {
            _context.Users.Entry(user).Property<string?>("PasswordHash").CurrentValue = passwordHash;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}