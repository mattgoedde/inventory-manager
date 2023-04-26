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
public class TenantsController : ODataController
{
    private readonly ITenantSecuredDbContextFactory<InventoryDbContext> _dbContextFactory;
    private readonly IMediator _mediator;

    public TenantsController(ITenantSecuredDbContextFactory<InventoryDbContext> dbContextFactory, IMediator mediator)
    {
        _dbContextFactory = dbContextFactory;
        _mediator = mediator;
    }

    [EnableQuery]
    public ActionResult<IEnumerable<TenantEntity>> Get()
    {
        var context = _dbContextFactory.Create(HttpContext.User.TenantId());
        return Ok(context.Tenants);
    }

    [EnableQuery]
    public ActionResult<TenantEntity> Get([FromRoute]Guid id)
    {
        var context = _dbContextFactory.Create(HttpContext.User.TenantId());

        var item = context.Tenants.Find(id);

        if (item is null) 
            return NotFound();

        return Ok(item);
    }

    [HttpPost("api/[controller]")]
    public async Task<ActionResult> CreateNewTenant([FromBody] TenantDto newTenant)
    {
        newTenant.Id = HttpContext.User.TenantId();

        var result = await _mediator.Send(new CreateTenantRequest(newTenant));

        if (result is null) return BadRequest();

        return Created($"odata/Tenants({result.Id})", result);
    }

    [HttpDelete("api/[controller]")]
    public async Task<ActionResult> DeleteTenant([FromBody] TenantDto tenant)
    {
        tenant.Id = HttpContext.User.TenantId();

        await _mediator.Send(new DeleteTenantRequest(tenant));

        return NoContent();
    }

    [HttpPut("api/[controller]")]
    public async Task<ActionResult> UpsertTenant([FromBody] TenantDto tenant)
    {
        tenant.Id = HttpContext.User.TenantId();

        var result = await _mediator.Send(new UpsertTenantRequest(tenant));

        return Ok(result);
    }
}
