using IdentityApi.Application.Dto;
using IdentityApi.Application.Services;
using IdentityApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request,
        [FromServices] AuthService authService,
        [FromServices] TokenService tokenService,
        CancellationToken cancellationToken)
    {
        var user = await authService.LoginAsync(request.User, request.Password, cancellationToken);
        var token = tokenService.GenerateAccessToken(user);
        var response = new LoginResponse(user, token);

        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh()
    {
        return Ok();
    }
}