﻿namespace Inventory.Domain.DataTransferObjects;

public class TagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
