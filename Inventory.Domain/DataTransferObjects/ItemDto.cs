namespace Inventory.Domain.DataTransferObjects;

public class ItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public LocationDto Location { get; set; } = default!;
}
