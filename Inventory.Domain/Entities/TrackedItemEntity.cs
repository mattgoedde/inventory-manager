namespace Inventory.Domain.Entities;

public class TrackedItemEntity : ItemEntity
{
    public string LotNumber { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
}