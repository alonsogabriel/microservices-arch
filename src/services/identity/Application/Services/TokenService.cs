using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityApi.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApi.Application.Services;

public class TokenService(IOptions<JwtSettings> settings)
{
    private readonly JwtSettings _settings = settings.Value;
    public string GenerateAccessToken(User user)
    {
        var signingCredentials = new SigningCredentials(_settings.GetSecurityKey(), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            expires: DateTime.UtcNow.AddSeconds(_settings.ExpirySeconds),
            signingCredentials: signingCredentials,
            claims: BuildUserClaims(user)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static List<Claim> BuildUserClaims(User user)
    {
        List<Claim> claims = [];

        AddClaim(claims, JwtRegisteredClaimNames.Jti, Guid.CreateVersion7().ToString());
        AddClaim(claims, JwtRegisteredClaimNames.Sub, user.Id.ToString());
        AddClaim(claims, JwtRegisteredClaimNames.PreferredUsername, user.Username);
        AddClaim(claims, JwtRegisteredClaimNames.Email, user.Email);
        AddClaim(claims, JwtRegisteredClaimNames.Name, user.Name);
        if (user.PhoneNumber is not null)
        {
            AddClaim(claims, JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber);
        }
        AddClaim(claims, "created_at", user.CreatedAt.ToString("O"));

        return claims;
    }

    private static void AddClaim(List<Claim> claims, string name, string value)
    {
        claims.Add(new Claim(name, value));
    }
}