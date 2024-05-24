using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

public class ItemController : Controller
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemMapper _itemMapper;
    private readonly ICollectionRepository _collectionRepository;

    public ItemController(IItemRepository itemRepository, IItemMapper itemMapper, ICollectionRepository collectionRepository)
    {
        _itemRepository = itemRepository;
        _itemMapper = itemMapper;
        _collectionRepository = collectionRepository;
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

    [HttpGet]
    public async Task<IActionResult> Add(string collectionId)
    {
        var collection = await _collectionRepository.GetCollectionByIdAsync(Guid.Parse(collectionId));
        if (collection == null)
        {
            //TODO : collection not found
            return NotFound(collectionId);
        }

        var viewModel = _itemMapper.MapToCreateItemViewModel(collection);
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateItemViewModel viewModel)
    {
        var item = _itemMapper.MapToItem(viewModel);
        await _itemRepository.AddItemAsync(item);
        return RedirectToAction("GetCollection", "Collection", new { collectionId = viewModel.CollectionId });
    }
}
