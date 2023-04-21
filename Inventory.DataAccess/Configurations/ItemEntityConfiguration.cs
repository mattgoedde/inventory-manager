using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class ItemEntityConfiguration : IEntityTypeConfiguration<ItemEntity>
{
    private readonly Guid _tenantId;

    public ItemEntityConfiguration(Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.HasQueryFilter(e => e.TenantId == _tenantId);
        builder.HasOne(i => i.Tenant).WithMany(t => t.Items).HasForeignKey(i => i.TenantId).OnDelete(DeleteBehavior.NoAction);
    }
}