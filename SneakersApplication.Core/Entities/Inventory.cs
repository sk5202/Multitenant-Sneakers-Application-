namespace SneakersApplication.Core.Entities;

public class Inventory : EntityBase
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}