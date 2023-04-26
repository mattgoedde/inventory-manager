namespace Inventory.Domain.Entities;

public class LocationTypeEntity : ITenantSecuredEntity, IEntity
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public virtual TenantEntity Tenant { get; set; } = default!;

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<LocationEntity> Locations { get; } = new List<LocationEntity>();
}