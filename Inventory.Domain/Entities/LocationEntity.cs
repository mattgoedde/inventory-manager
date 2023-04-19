namespace Inventory.Domain.Entities;

public class LocationEntity : TenantConfigurationEntity
{
    public string Name { get; set; } = string.Empty;
    public Guid LocationTypeId { get; set; }
    public Guid? ParentLocationId { get; set; }

    public LocationTypeEntity LocationType { get; set; } = default!;
    public virtual LocationEntity? ParentLocation { get; set; }
    public virtual ICollection<LocationEntity> ChildLocations { get; set; } = new List<LocationEntity>();
    public virtual IEnumerable<TrackedItemEntity> TrackedItems { get; } = Enumerable.Empty<TrackedItemEntity>();
    public virtual IEnumerable<UntrackedItemEntity> UntrackedItems { get; } = Enumerable.Empty<UntrackedItemEntity>();
}