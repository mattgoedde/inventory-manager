using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class TagEntityConfiguration : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder) 
    { 
        builder.HasOne(t => t.Tenant).WithMany(t => t.Tags).HasForeignKey(t => t.TenantId);
    }
}
