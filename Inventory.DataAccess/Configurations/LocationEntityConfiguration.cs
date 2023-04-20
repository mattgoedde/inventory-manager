using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.DataAccess.Configurations;

public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.HasOne(l => l.Tenant).WithMany(t => t.Locations).HasForeignKey(l => l.TenantId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(l => l.LocationType).WithMany(lt => lt.Locations).HasForeignKey(l => l.LocationTypeId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(l => l.ParentLocation).WithMany(l => l.ChildLocations).HasForeignKey(l => l.ParentLocationId).OnDelete(DeleteBehavior.NoAction);
    }
}
