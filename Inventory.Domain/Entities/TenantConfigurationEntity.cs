namespace Inventory.Domain.Entities;

public interface ITenantSecuredEntity
{
    Guid TenantId { get; set; }
    TenantEntity Tenant { get; set; }
}