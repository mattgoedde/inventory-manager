using System.Security.Claims;

namespace Inventory.Api.Security;

public static class ClaimsPrincipalExtensions
{
    public static Guid TenantId(this ClaimsPrincipal user)
    {
        var tenantClaim = user.Claims.First(c => c.Type == "tenant");
        if (tenantClaim is null) throw new Exception("User does not have tenant claim");
        if (Guid.TryParse(tenantClaim.Value, out var tenantId)) return tenantId;
        throw new Exception("User's TenantId could not be parsed");
    }
}
