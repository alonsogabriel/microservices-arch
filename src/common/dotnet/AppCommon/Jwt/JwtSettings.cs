using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AppCommon.Jwt;

public class JwtSettings
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public bool RequiresHttp { get; init; }
    public int ExpirySeconds { get; init; }
    public int ClockSkewSeconds { get; set; }
    public string SecretKey { get; init; }
    public SecurityKey GetSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
    }

    public TimeSpan ClockSkew => TimeSpan.FromSeconds(ClockSkewSeconds);
}