namespace Inventory.Domain.Entities;

public class LocationTypeEntity : TenantConfigurationEntity
{
    public string Name { get; set; } = string.Empty;
}