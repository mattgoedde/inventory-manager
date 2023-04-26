using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess;

public interface ITenantSecuredDbContextFactory<out TDbContext>
    where TDbContext : DbContext
{
    TDbContext Create(Guid tenantId);
}

internal class InventoryDbContextFactory : ITenantSecuredDbContextFactory<InventoryDbContext>
{
    private readonly DbContextOptions<InventoryDbContext> _options;

    public InventoryDbContextFactory(DbContextOptions<InventoryDbContext> options)
    {
        _options = options;
    }

    public InventoryDbContext Create(Guid tenantId) => new(_options, tenantId);
}