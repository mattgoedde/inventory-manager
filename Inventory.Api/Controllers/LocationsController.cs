using Inventory.Api.Security;
using Inventory.DataAccess;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Inventory.Api.Controllers;

public class LocationsController : ODataController
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;

    public LocationsController(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    [Authorize]
    [RequireClaim("tenant")]
    [EnableQuery]
    public ActionResult<IEnumerable<LocationEntity>> Get()
    {
        using var context = _dbContextFactory.CreateAsync(HttpContext.User.TenantId());
        return Ok(context.Locations);
    }
}
