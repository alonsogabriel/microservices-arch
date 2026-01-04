using IdentityApi;
using IdentityApi.Application.Services;
using IdentityApi.Domain;
using IdentityApi.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
DomainDependencies.AddAll(builder.Services);
InfrastructureDependencies.AddAll(builder.Services);
builder.Services.AddScoped<TokenService>();
builder.Services.AddControllers();

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();

await app.MigrateDatabaseAsync();

app.Run();
