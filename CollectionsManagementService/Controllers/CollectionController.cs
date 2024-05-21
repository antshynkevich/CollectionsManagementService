using CollectionsManagementService.Services;
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
    private readonly IModelMapper _modelMapper;

    public CollectionController(ICollectionRepository collectionRepository,
        UserManager<ApplicationUser> userManager,
        IModelMapper modelMapper,
        CategoryRepository categoryRepository)
    {
        _collectionRepository = collectionRepository;
        _userManager = userManager;
        _modelMapper = modelMapper;
        _categoryRepository = categoryRepository;
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

        var detailedCollectionVm = _modelMapper.MapToDetailedCollection(collection);
        return View("DisplayCollection", detailedCollectionVm);
    }

    [HttpGet("/[controller]/mycollections")]
    public async Task<IActionResult> ShowUserCollections()
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var userCollections = await _collectionRepository.GetCollectionsByUserIdAsync(currentUser.Id);
        var userCollectionsVM = _modelMapper.MapToCollectionViewModelList(userCollections);
        return View("MyCollections", userCollectionsVM);
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        //TODO: rewrite or delete this method
        var collectionsWithFields = await _collectionRepository.GetAllAsync();
        return View(collectionsWithFields);
    }

    [HttpGet("/[controller]/create")]
    public async Task<IActionResult> CreateCollection()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var viewModel = new CreateCollectionViewModel(categories);
        return View("Create", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCollection(CreateCollectionViewModel viewModel)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var collection = _modelMapper.MapToCollection(viewModel, currentUser.Id);
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

        var collectoinVM = _modelMapper.MapToUpdateCollectionVM(collection);
        return View(collectoinVM);
    }

    [HttpPost("/[controller]/update/{collectionId}")]
    public async Task<IActionResult> UpdateCollectionAsync(UpdateCollectionViewModel collectionViewModel)
    {
        var collectionUpdated = _modelMapper.MapToCollection(collectionViewModel);
        await _collectionRepository.UpdateCollectionAsync(collectionUpdated);
        return RedirectToAction(nameof(GetCollection), new { collectionId = collectionViewModel.CollectionId });
    }
}