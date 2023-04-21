using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess;

public interface ITenantSecuredDbContextFactory<out TDbContext>
    where TDbContext : DbContext
{
    TDbContext CreateAsync(Guid tenantId);
}

internal class InventoryDbContextFactory : ITenantSecuredDbContextFactory<InventoryDbContext>
{
    private readonly DbContextOptions<InventoryDbContext> _options;

    public InventoryDbContextFactory(DbContextOptions<InventoryDbContext> options)
    {
        _options = options;
    }

    public InventoryDbContext CreateAsync(Guid tenantId) => new(_options, tenantId);
}