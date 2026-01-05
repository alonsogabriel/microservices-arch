using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCommon.Jwt;

public static class AppAuthentication
{
    public static void AddJwtAuthentication(WebApplicationBuilder builder)
    {
        builder.Services
            .AddOptions<JwtSettings>()
            .BindConfiguration(nameof(JwtSettings))
            .ValidateOnStart();

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var settings = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>()!;
                options.RequireHttpsMetadata = settings.RequiresHttp;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = settings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = settings.GetSecurityKey(),
                    ClockSkew = settings.ClockSkew,
                };
            });

        builder.Services.AddAuthorization();
    }
}