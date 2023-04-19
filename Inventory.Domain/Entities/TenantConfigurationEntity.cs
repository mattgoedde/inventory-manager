namespace Inventory.Domain.Entities;

public abstract class TenantConfigurationEntity : Entity
{
    public Guid TenantId { get; set; }
    public virtual TenantEntity Tenant { get; set; } = default!;
}