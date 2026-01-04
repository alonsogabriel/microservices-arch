using System.Text.RegularExpressions;
using IdentityApi.Domain.Entities;
using IdentityApi.Domain.Exceptions;
using IdentityApi.Domain.Repositories;

namespace IdentityApi.Domain.Services;

public partial class AuthService(
    IUserRepository userRepository
)
{
    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled)]
    private static partial Regex EmailRegex();
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> LoginAsync(string user, string password, CancellationToken cancellationToken = default)
    {
        var userEntity = await FindUserAsync(user, cancellationToken) ?? throw new DomainException("User not found");

        if (!await _userRepository.VerifyPasswordAsync(userEntity, password, cancellationToken))
        {
            throw new DomainException("Password is wrong.");
        }

        // TODO send to queue to create session

        return userEntity;
    }

    public async Task LogoutAsync()
    {

    }

    private async Task<User?> FindUserAsync(string user, CancellationToken cancellationToken)
    {
        if (EmailRegex().IsMatch(user))
        {
            return await _userRepository.FindByEmailAsync(user, cancellationToken);
        }
        return await _userRepository.FindByUsernameAsync(user, cancellationToken);
    }
}