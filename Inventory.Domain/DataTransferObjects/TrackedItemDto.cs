namespace Inventory.Domain.DataTransferObjects;

public class TrackedItemDto : ItemDto
{
    public string LotNumber { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
}
