using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;
internal class TenantSecuredEntityConfiguration : IEntityTypeConfiguration<ITenantSecuredEntity>
{
    private readonly Guid _tenantId;

    public TenantSecuredEntityConfiguration(Guid tenantId)
    {
        ArgumentNullException.ThrowIfNull(tenantId, nameof(tenantId));
        if (tenantId == Guid.Empty) throw new ArgumentException("Tenant Id cannot be empty", nameof(tenantId));

        _tenantId = tenantId;
    }

    public void Configure(EntityTypeBuilder<ITenantSecuredEntity> builder)
    {
        builder.HasQueryFilter(e => e.TenantId == _tenantId);
    }
}
