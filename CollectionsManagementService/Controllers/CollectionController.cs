using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

[Authorize]
[Route("[controller]/[action]")]
public class CollectionController : Controller
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICollectionMapper _collectionMapper;
    private readonly ICloudService _cloudService;

    public CollectionController(ICollectionRepository collectionRepository,
        UserManager<ApplicationUser> userManager,
        ICollectionMapper collectionMapper,
        CategoryRepository categoryRepository,
        ICloudService cloudService)
    {
        _collectionRepository = collectionRepository;
        _userManager = userManager;
        _collectionMapper = collectionMapper;
        _categoryRepository = categoryRepository;
        _cloudService = cloudService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCollection(string collectionId)
    {
        await Console.Out.WriteLineAsync($"collection id = {collectionId}");
        var collection = await _collectionRepository.GetWithItemsByIdAsync(Guid.Parse(collectionId));
        if (collection == null)
        {
            return NotFound();
            //TODO: throw not found
        }

        var detailedCollectionVm = _collectionMapper.MapToDetailedCollection(collection);
        return View("DisplayCollection", detailedCollectionVm);
    }

    [HttpGet("/[controller]/mycollections")]
    public async Task<IActionResult> ShowUserCollections()
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var userCollections = await _collectionRepository.GetCollectionsByUserIdAsync(currentUser.Id);
        var userCollectionsVM = _collectionMapper.MapToCollectionViewModelList(userCollections);
        return View("MyCollections", userCollectionsVM);
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //TODO: rewrite or delete this method
        var collectionsWithFields = await _collectionRepository.GetAllAsync();
        return View(collectionsWithFields);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var viewModel = new CreateCollectionViewModel(categories);
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCollectionViewModel viewModel)
    {
        if (viewModel.Image != null)
        {
            var result = await _cloudService.AddImageAsync(viewModel.Image);
            viewModel.ImageUrl = result.Url.ToString();
        }

        var currentUser = await _userManager.GetUserAsync(User);
        var collection = _collectionMapper.MapToCollection(viewModel, currentUser.Id);
        await _collectionRepository.AddAsync(collection);
        return RedirectToAction("Index");
    }

    [HttpGet("/[controller]/update/{collectionId}")]
    public async Task<IActionResult> UpdateCollection(string collectionId)
    {
        var collection = await _collectionRepository.GetCollectionByIdAsync(Guid.Parse(collectionId));
        if (collection == null)
        {
            return NotFound();
            //TODO: throw not found
        }

        var collectoinVM = _collectionMapper.MapToUpdateCollectionVM(collection);
        return View(collectoinVM);
    }

    [HttpPost("/[controller]/update/{collectionId}")]
    public async Task<IActionResult> UpdateCollection(UpdateCollectionViewModel collectionViewModel)
    {
        if (collectionViewModel.Image != null)
        {
            if (!string.IsNullOrEmpty(collectionViewModel.ImageUrl))
            {
                await _cloudService.DeleteImageAsync(collectionViewModel.ImageUrl);
            }

            var result = await _cloudService.AddImageAsync(collectionViewModel.Image);
            collectionViewModel.ImageUrl = result.Url.ToString();
        }

        var collectionUpdated = _collectionMapper.MapToCollection(collectionViewModel);
        await _collectionRepository.UpdateCollectionAsync(collectionUpdated);
        return RedirectToAction(nameof(GetCollection), new { collectionId = collectionViewModel.CollectionId });
    }

    [HttpGet]
    public async Task<IActionResult> DeleteCollection(string collectionId)
    {
        try
        {
            await _collectionRepository.DeleteCollectionAsync(Guid.Parse(collectionId));
        }
        catch (Exception)
        {
            return NotFound();
            //TODO: throw not found
        }

        return RedirectToAction(nameof(ShowUserCollections));
    }
}
