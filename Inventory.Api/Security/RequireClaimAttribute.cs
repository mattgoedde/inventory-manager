using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Inventory.Api.Security;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class RequireClaimAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _claimName;

    public RequireClaimAttribute(string claimName)
    {
        _claimName = claimName;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.HasClaim(p => p.Type == _claimName))
        {
            context.Result = new ForbidResult();
        }
    }
}
