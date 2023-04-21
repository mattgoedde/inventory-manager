using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class TenantEntityConfiguration : IEntityTypeConfiguration<TenantEntity>
{
    private readonly Guid _tenantId;

    public TenantEntityConfiguration(Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    public void Configure(EntityTypeBuilder<TenantEntity> builder)
    {
        builder.HasQueryFilter(e => e.Id == _tenantId);
    }
}