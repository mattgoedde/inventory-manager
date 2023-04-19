namespace Inventory.Domain.Entities;

public class ItemEntity : TenantConfigurationEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public Guid LocationId { get; set; }
    public virtual LocationEntity Location { get; set; } = default!;
    
    public virtual ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();
}
