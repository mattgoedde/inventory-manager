using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class LocationTypeEntityConfiguration : IEntityTypeConfiguration<LocationTypeEntity>
{
    public void Configure(EntityTypeBuilder<LocationTypeEntity> builder)
    {
        builder.HasOne(lt => lt.Tenant).WithMany(t => t.LocationTypes).HasForeignKey(lt => lt.TenantId);
    }
}