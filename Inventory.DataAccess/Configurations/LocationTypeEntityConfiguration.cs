using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class LocationTypeEntityConfiguration : IEntityTypeConfiguration<LocationTypeEntity>
{
    private readonly Guid _tenantId;

    public LocationTypeEntityConfiguration(Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    public void Configure(EntityTypeBuilder<LocationTypeEntity> builder)
    {
        builder.HasQueryFilter(e => e.TenantId == _tenantId);
        builder.HasOne(lt => lt.Tenant).WithMany(t => t.LocationTypes).HasForeignKey(lt => lt.TenantId).OnDelete(DeleteBehavior.NoAction);
    }
}