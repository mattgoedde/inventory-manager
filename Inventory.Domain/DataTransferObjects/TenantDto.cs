namespace Inventory.Domain.DataTransferObjects;

public class TenantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty; 
}
