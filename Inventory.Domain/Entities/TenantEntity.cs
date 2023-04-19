namespace Inventory.Domain.Entities;

public class TenantEntity : Entity
{
    public string Name { get; set; } = string.Empty;

    public virtual IEnumerable<LocationEntity> Locations { get; } = Enumerable.Empty<LocationEntity>();
    public virtual IEnumerable<LocationTypeEntity> LocationTypes { get; } = Enumerable.Empty<LocationTypeEntity>();
    public virtual IEnumerable<TagEntity> Tags { get; } = Enumerable.Empty<TagEntity>();
    public virtual IEnumerable<TrackedItemEntity> TrackedItems { get; } = Enumerable.Empty<TrackedItemEntity>();
    public virtual IEnumerable<UntrackedItemEntity> UntrackedItems { get; } = Enumerable.Empty<UntrackedItemEntity>();
}