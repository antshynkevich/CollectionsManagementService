using CollectionsManagementService.Services;
using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

[Authorize]
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

    [HttpGet("/mycollections")]
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
        var collectionsWithFields = await _collectionRepository.GetAllAsync();
        return View(collectionsWithFields);
    }

    [HttpGet]
    public async Task<IActionResult> CreateCollectionAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var viewModel = new CreateCollectionViewModel(categories);
        return View("Create", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCollectionAsync(CreateCollectionViewModel viewModel)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        var collection = _modelMapper.MapToCollection(viewModel, currentUser.Id);
        await _collectionRepository.AddAsync(collection);
        return RedirectToAction("Index");
    }
}
