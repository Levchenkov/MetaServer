using System.Security.Claims;

namespace MetaGame.Server.Console;

public static class Extensions
{
    public static Guid GetId(this ClaimsPrincipal user) => Guid.NewGuid();
}