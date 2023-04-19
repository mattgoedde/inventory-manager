using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class TrackedItemEntityConfiguration : IEntityTypeConfiguration<TrackedItemEntity>
{
    public void Configure(EntityTypeBuilder<TrackedItemEntity> builder)
    {
        builder.HasOne(i => i.Tenant).WithMany(t => t.TrackedItems).HasForeignKey(i => i.TenantId);
        builder.HasOne(i => i.Location).WithMany(l => l.TrackedItems).HasForeignKey(i => i.LocationId);
    }
}