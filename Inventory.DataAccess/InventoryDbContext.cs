using Inventory.DataAccess.Configurations;
using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DataAccess;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<LocationEntity>(new LocationEntityConfiguration());
        modelBuilder.ApplyConfiguration<LocationTypeEntity>(new LocationTypeEntityConfiguration());
        modelBuilder.ApplyConfiguration<TagEntity>(new TagEntityConfiguration());
        modelBuilder.ApplyConfiguration<TenantEntity>(new TenantEntityConfiguration());
        modelBuilder.ApplyConfiguration<TrackedItemEntity>(new TrackedItemEntityConfiguration());
        modelBuilder.ApplyConfiguration<UntrackedItemEntity>(new UntrackedItemEntityConfiguration());
    }

    public DbSet<TenantEntity> Tenants { get; set; } = default!;
    public DbSet<LocationEntity> Locations { get; set; } = default!;
    public DbSet<LocationTypeEntity> LocationTypes { get; set; } = default!;
    public DbSet<TagEntity> Tags { get; set; } = default!;

    public DbSet<TrackedItemEntity> TrackedItems { get; set; } = default!;
    public DbSet<UntrackedItemEntity> UntrackedItems { get; set; } = default!;
}
