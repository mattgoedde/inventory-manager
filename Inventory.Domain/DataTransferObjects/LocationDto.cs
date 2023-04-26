namespace Inventory.Domain.DataTransferObjects;

public class LocationDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public LocationTypeDto LocationType { get; set; } = default!;
    public LocationDto? ParentLocation { get; set; }
    public ICollection<LocationDto> ChildLocations { get; set; } = new List<LocationDto>();
}
