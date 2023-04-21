using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
{
    private readonly Guid _tenantId;

    public LocationEntityConfiguration(Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.HasQueryFilter(e => e.TenantId == _tenantId);
        builder.HasOne(l => l.Tenant).WithMany(t => t.Locations).HasForeignKey(l => l.TenantId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(l => l.LocationType).WithMany(lt => lt.Locations).HasForeignKey(l => l.LocationTypeId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(l => l.ParentLocation).WithMany(l => l.ChildLocations).HasForeignKey(l => l.ParentLocationId).OnDelete(DeleteBehavior.NoAction);
    }
}
