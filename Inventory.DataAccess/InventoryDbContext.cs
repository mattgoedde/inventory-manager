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

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
        _tenantId = Guid.NewGuid();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new LocationEntityConfiguration(_tenantId))
            .ApplyConfiguration(new LocationTypeEntityConfiguration(_tenantId))
            .ApplyConfiguration(new TagEntityConfiguration(_tenantId))
            .ApplyConfiguration(new TenantEntityConfiguration(_tenantId))
            .ApplyConfiguration(new ItemEntityConfiguration(_tenantId));
    }

    public DbSet<TenantEntity> Tenants { get; set; } = default!;
    public DbSet<LocationEntity> Locations { get; set; } = default!;
    public DbSet<LocationTypeEntity> LocationTypes { get; set; } = default!;
    public DbSet<TagEntity> Tags { get; set; } = default!;
    public DbSet<TrackedItemEntity> TrackedItems { get; set; } = default!;
    public DbSet<UntrackedItemEntity> UntrackedItems { get; set; } = default!;
}
