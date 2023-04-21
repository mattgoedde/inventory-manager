﻿using Inventory.Api.Security;
using Inventory.DataAccess;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Inventory.Api.Controllers;

public class UntrackedItemController : ODataController
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;

    public UntrackedItemController(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    [Authorize]
    [RequireClaim("tenant")]
    [EnableQuery]
    public ActionResult<IEnumerable<UntrackedItemEntity>> Get()
    {
        using var context = _dbContextFactory.CreateAsync(HttpContext.User.TenantId());
        return Ok(context.UntrackedItems);
    }
}