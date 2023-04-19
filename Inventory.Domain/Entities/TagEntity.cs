namespace Inventory.Domain.Entities;

public class TagEntity : TenantConfigurationEntity
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<ItemEntity> Items { get; set; } = new List<ItemEntity>();
}