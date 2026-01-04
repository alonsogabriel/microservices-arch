using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace AppCommon;

public static class Utils
{
    public static string? UserId(this ControllerBase controller, string? claimType = null)
    {
        return controller.User.FindFirstValue(claimType ?? ClaimTypes.NameIdentifier);
    }

    public static Guid? UserGuid(this ControllerBase controller, string? claimType = null)
    {
        var id = controller.UserId(claimType);
        return id is null ? null : Guid.Parse(id);
    }
}