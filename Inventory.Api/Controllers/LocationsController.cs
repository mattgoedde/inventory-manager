using Inventory.DataAccess;
using Inventory.Domain.DataTransferObjects;
using Inventory.Domain.Entities;
using Inventory.Logic.Commands;
using Inventory.Logic.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Inventory.Api.Controllers;

[Authorize]
[RequireClaim("tenant")]
public class LocationsController : ODataController
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;
    private readonly IMediator _mediator;

    public LocationsController(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory, IMediator mediator)
    {
        _dbContextFactory = dbContextFactory;
        _mediator = mediator;
    }

    [EnableQuery]
    public ActionResult<IEnumerable<LocationEntity>> Get()
    {
        var context = _dbContextFactory.Create(HttpContext.User.TenantId());
        return Ok(context.Locations);
    }

    [HttpPost("api/[controller]")]
    public async Task<ActionResult> Create([FromBody]LocationDto location)
    {
        var tenantId = HttpContext.User.TenantId();

        var result = await _mediator.Send(new CreateLocationRequest(tenantId, location));

        if (result is null) return BadRequest();

        return Created($"odata/Locations({location.Id})", result);
    }
}
