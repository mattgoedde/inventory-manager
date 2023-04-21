using Inventory.DataAccess;
using Inventory.Domain.Entities;
using Inventory.Logic.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Inventory.Api.Controllers;

public class TenantsController : ODataController
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;

    public TenantsController(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    [Authorize]
    [RequireClaim("tenant")]
    [EnableQuery]
    public ActionResult<IEnumerable<TenantEntity>> Get()
    {
        using var context = _dbContextFactory.CreateAsync(HttpContext.User.TenantId());
        return Ok(context.Tenants);
    }
}
