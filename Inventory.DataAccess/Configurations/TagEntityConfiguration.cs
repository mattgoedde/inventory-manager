using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class TagEntityConfiguration : IEntityTypeConfiguration<TagEntity>
{
    private readonly Guid _tenantId;

    public TagEntityConfiguration(Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    public void Configure(EntityTypeBuilder<TagEntity> builder) 
    {
        builder.HasQueryFilter(e => e.TenantId == _tenantId);
        builder.HasOne(t => t.Tenant).WithMany(t => t.Tags).HasForeignKey(t => t.TenantId).OnDelete(DeleteBehavior.NoAction);
    }
}
