namespace Inventory.Domain.Entities;

public class LocationEntity : ITenantSecuredEntity, IEntity
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }

    public string Name { get; set; } = string.Empty;
    public Guid LocationTypeId { get; set; }
    public Guid? ParentLocationId { get; set; }

    public virtual TenantEntity Tenant { get; set; } = default!;
    public LocationTypeEntity LocationType { get; set; } = default!;
    public virtual LocationEntity? ParentLocation { get; set; }
    public virtual ICollection<LocationEntity> ChildLocations { get; } = new List<LocationEntity>();
    public virtual ICollection<TrackedItemEntity> TrackedItems { get; } = new List<TrackedItemEntity>();
    public virtual ICollection<UntrackedItemEntity> UntrackedItems { get; } = new List<UntrackedItemEntity>();
}