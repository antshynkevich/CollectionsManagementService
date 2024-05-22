using CollectionsManagementService.Services;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

public class ItemController : Controller
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemMapper _itemMapper;

    public ItemController(IItemRepository itemRepository, IItemMapper itemMapper)
    {
        _itemRepository = itemRepository;
        _itemMapper = itemMapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string itemId)
    {
        var item = await _itemRepository.GetByIdAsync(Guid.Parse(itemId));
        if (item == null)
        {
            return NotFound();
        }

        var itemViewModel = _itemMapper.MapToItemViewModel(item);
        return View(itemViewModel);
    }
}
