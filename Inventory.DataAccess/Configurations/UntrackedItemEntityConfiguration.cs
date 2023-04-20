using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class UntrackedItemEntityConfiguration : IEntityTypeConfiguration<UntrackedItemEntity>
{
    public void Configure(EntityTypeBuilder<UntrackedItemEntity> builder)
    {
        builder.HasOne(i => i.Tenant).WithMany(t => t.UntrackedItems).HasForeignKey(i => i.TenantId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(i => i.Location).WithMany(l => l.UntrackedItems).HasForeignKey(i => i.LocationId).OnDelete(DeleteBehavior.NoAction);
    }
}