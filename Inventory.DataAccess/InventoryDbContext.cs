using Inventory.DataAccess.Configurations;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess;

public class InventoryDbContext : DbContext
{
    private readonly Guid _tenantId;

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options, Guid tenantId) 
        : base(options) 
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new TenantSecuredEntityConfiguration(_tenantId))
            .ApplyConfiguration(new LocationEntityConfiguration())
            .ApplyConfiguration(new LocationTypeEntityConfiguration())
            .ApplyConfiguration(new TagEntityConfiguration())
            .ApplyConfiguration(new TenantEntityConfiguration())
            .ApplyConfiguration(new TrackedItemEntityConfiguration())
            .ApplyConfiguration(new UntrackedItemEntityConfiguration());
    }

    public DbSet<TenantEntity> Tenants { get; set; } = default!;
    public DbSet<LocationEntity> Locations { get; set; } = default!;
    public DbSet<LocationTypeEntity> LocationTypes { get; set; } = default!;
    public DbSet<TagEntity> Tags { get; set; } = default!;
    public DbSet<TrackedItemEntity> TrackedItems { get; set; } = default!;
    public DbSet<UntrackedItemEntity> UntrackedItems { get; set; } = default!;
}
