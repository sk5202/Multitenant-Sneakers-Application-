namespace SneakersApplication.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _dbContext;

    public InventoryRepository(InventoryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Inventory> AddAsync(InventoryDto InventoryDto)
    {
        var Inventory = new Inventory { Name = InventoryDto.Name, Price = InventoryDto.Price };

        await _dbContext.Inventory.AddAsync(Inventory);
        await _dbContext.SaveChangesAsync();

        return Inventory;
    }

    public async Task<IReadOnlyList<Inventory>> GetAllAsync()
    {
        return await _dbContext.Inventory.ToListAsync();
    }
}