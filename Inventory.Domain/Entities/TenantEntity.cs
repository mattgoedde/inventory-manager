namespace Inventory.Domain.Entities;

public class TenantEntity : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual IEnumerable<LocationEntity> Locations { get; } = Enumerable.Empty<LocationEntity>();
    public virtual IEnumerable<LocationTypeEntity> LocationTypes { get; } = Enumerable.Empty<LocationTypeEntity>();
    public virtual IEnumerable<TagEntity> Tags { get; } = Enumerable.Empty<TagEntity>();
    public virtual IEnumerable<ItemEntity> Items { get; } = Enumerable.Empty<ItemEntity>();
}