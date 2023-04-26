using Inventory.DataAccess;
using Inventory.Domain.Entities;
using Inventory.Logic.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Inventory.Api.Controllers;

[Authorize]
[RequireClaim("tenant")]
public class UntrackedItemsController : ODataController
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;

    public UntrackedItemsController(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    [EnableQuery]
    public ActionResult<IEnumerable<UntrackedItemEntity>> Get()
    {
        using var context = _dbContextFactory.Create(HttpContext.User.TenantId());
        return Ok(context.UntrackedItems);
    }
}
