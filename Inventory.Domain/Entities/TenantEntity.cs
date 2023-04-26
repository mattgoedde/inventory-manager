namespace Inventory.Domain.Entities;

public class TenantEntity : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<LocationEntity> Locations { get; } = new List<LocationEntity>();
    public virtual ICollection<LocationTypeEntity> LocationTypes { get; } = new List<LocationTypeEntity>();
    public virtual ICollection<TagEntity> Tags { get; } = new List<TagEntity>();
    public virtual ICollection<ItemEntity> Items { get; } = new List<ItemEntity>();
}