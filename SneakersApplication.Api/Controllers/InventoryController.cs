namespace SneakersApplication.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class InventoryController : ControllerBase
{
    private readonly IInventoryRepository _InventoryRepository;

    public InventoryController(IInventoryRepository InventoryRepository)
    {
        _InventoryRepository = InventoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(InventoryDto InventoryDto)
    {
        var Inventory = await _InventoryRepository.AddAsync(InventoryDto);

        return Created(string.Empty, Inventory);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync()
    {
        var list = await _InventoryRepository.GetAllAsync();

        return Ok(list);
    }
}