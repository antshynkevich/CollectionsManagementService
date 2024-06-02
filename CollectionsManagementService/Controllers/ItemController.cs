using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

[Authorize(Policy = "UserNotBlocked")]
public class ItemController : Controller
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemMapper _itemMapper;
    private readonly ICollectionRepository _collectionRepository;
    private readonly IAuthorizationService _authorizationService;

    public ItemController(IItemRepository itemRepository, IItemMapper itemMapper, 
        ICollectionRepository collectionRepository, IAuthorizationService authorizationService)
    {
        _itemRepository = itemRepository;
        _itemMapper = itemMapper;
        _collectionRepository = collectionRepository;
        _authorizationService = authorizationService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index(string itemId)
    {
        bool isValid = Guid.TryParse(itemId, out Guid guiditemId);
        if (!isValid) return NotFound();

        var item = await _itemRepository.GetByIdAsync(guiditemId);
        if (item == null)
        {
            return NotFound();
        }

        var itemViewModel = _itemMapper.MapToDetailedItemViewModel(item);
        return View(itemViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Add(string collectionId)
    {
        bool isValid = Guid.TryParse(collectionId, out Guid guidCollectionId);
        if (!isValid) return NotFound();

        var collection = await _collectionRepository.GetCollectionByIdAsync(guidCollectionId);
        if (collection == null)
        {
            //TODO : collection not found
            return NotFound(collectionId);
        }

        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, collection, "CollectionOwnerOrAdminPolicy");
        if (!authorizationResult.Succeeded)
            return new ForbidResult();

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

    [HttpGet]
    public async Task<IActionResult> Update(string itemId)
    {
        bool isValid = Guid.TryParse(itemId, out Guid guidItemId);
        if (!isValid) return NotFound();

        var item = await _itemRepository.GetByIdAsync(guidItemId);
        if (item == null)
        {
            return NotFound();
            //TODO: throw not found
        }

        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, item.Collection, "CollectionOwnerOrAdminPolicy");

        if (!authorizationResult.Succeeded)
            return new ForbidResult();

        var itemToUpdVm = _itemMapper.MapToUpdateItemViewModel(item);
        return View(itemToUpdVm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateItemViewModel viewModel)
    {
        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, viewModel, "CollectionOwnerOrAdminPolicy");
        if (!authorizationResult.Succeeded)
            return new ForbidResult();

        var item = _itemMapper.MapToItem(viewModel);
        try
        {
            await _itemRepository.UpdateItemAsync(item);
        }
        catch (Exception)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index), new { itemId = viewModel.ItemId });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string itemId)
    {
        bool isValid = Guid.TryParse(itemId, out Guid guidItemId);
        if (!isValid) return NotFound();

        var collectionData = new Collection();
        try
        {
            collectionData = await _itemRepository.GetCollectionDataByItemIdAsync(guidItemId);
        }
        catch (Exception)
        {
            return NotFound(itemId);
        }

        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, collectionData, "CollectionOwnerOrAdminPolicy");
        if (!authorizationResult.Succeeded)
            return new ForbidResult();

        await _itemRepository.DeleteItemAsync(guidItemId);
        return RedirectToAction("GetCollection", "Collection", new { collectionId = collectionData.CollectionId.ToString() });
    }
}
