using SneakersApplication.Core.Entities;

namespace SneakersApplication.Core.Abstractions;

public interface IInventoryRepository
{
    Task<Inventory> AddAsync(InventoryDto InventoryDto);

    Task<IReadOnlyList<Inventory>> GetAllAsync();
}