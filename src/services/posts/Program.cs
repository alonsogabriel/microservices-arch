using AppCommon.Jwt;
using PostsApi.Domain.Services;
using PostsApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
AppAuthentication.AddJwtAuthentication(builder);
InfrastructureDependecies.AddAll(builder.Services);
builder.Services.AddScoped<PostService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();