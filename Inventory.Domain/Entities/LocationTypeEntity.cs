namespace Inventory.Domain.Entities;

public class LocationTypeEntity : TenantConfigurationEntity
{
    public string Name { get; set; } = string.Empty;

    public virtual IEnumerable<LocationEntity> Locations { get; } = Enumerable.Empty<LocationEntity>();
}