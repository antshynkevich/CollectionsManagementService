using CollectionsManagementService.Services;
using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels.Collection;
using DataORMLayer.Models;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

[Authorize(Policy = "UserNotBlocked")]
[Route("[controller]/[action]")]
public class CollectionController : Controller
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICollectionMapper _collectionMapper;
    private readonly ICloudService _cloudService;
    private readonly IAuthorizationService _authorizationService;

    public CollectionController(ICollectionRepository collectionRepository,
        UserManager<ApplicationUser> userManager,
        ICollectionMapper collectionMapper,
        CategoryRepository categoryRepository,
        ICloudService cloudService, 
        IAuthorizationService authorizationService)
    {
        _collectionRepository = collectionRepository;
        _userManager = userManager;
        _collectionMapper = collectionMapper;
        _categoryRepository = categoryRepository;
        _cloudService = cloudService;
        _authorizationService = authorizationService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index(string sortOrder, int? categoryId)
    {
        ViewData["DateSortParm"] = (string.IsNullOrEmpty(sortOrder) || sortOrder == "date_desc") ? "date" : "date_desc";
        ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
        ViewData["Category"] = categoryId;
        Helper.SortSignHelper(sortOrder, out string? nameSign, out string? dateSing);
        ViewData["NameSign"] = nameSign;
        ViewData["DateSign"] = dateSing;
        
        var sortedCollections = await _collectionRepository.GetSortedCollectionsAsync(sortOrder, categoryId);
        var allCollectionsVm = _collectionMapper.MapToCollectionViewModelList(sortedCollections);
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        return View(new CollectionFilteredViewModel(categories, allCollectionsVm));
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetCollection(string collectionId)
    {
        bool isValid = Guid.TryParse(collectionId, out Guid guidCollectionId);
        if (!isValid) return NotFound();

        var collection = await _collectionRepository.GetWithItemsByIdAsync(guidCollectionId);
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
    public async Task<IActionResult> Create()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        var viewModel = new CreateCollectionViewModel(categories);
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCollectionViewModel viewModel)
    {
        if (ModelState["CategoryId"]?.Errors.Count > 0)
        {
            return View(viewModel);
        }

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
        bool isValid = Guid.TryParse(collectionId, out Guid guidCollectionId);
        if (!isValid) return NotFound();

        var collection = await _collectionRepository.GetCollectionByIdAsync(guidCollectionId);
        if (collection == null)
        {
            return NotFound();
            //TODO: throw not found
        }

        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, collection, "CollectionOwnerOrAdminPolicy");

        if (!authorizationResult.Succeeded)
            return new ForbidResult();

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
        // TODO: add try catch
        await _collectionRepository.UpdateCollectionAsync(collectionUpdated);
        return RedirectToAction(nameof(GetCollection), new { collectionId = collectionViewModel.CollectionId });
    }

    [HttpGet]
    public async Task<IActionResult> DeleteCollection(string collectionId)
    {
        bool isValid = Guid.TryParse(collectionId, out Guid guidCollectionId);
        if (!isValid) return NotFound();
        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, new Collection() { UserId = collectionId }, "CollectionOwnerOrAdminPolicy");
        if (!authorizationResult.Succeeded)
            return new ForbidResult();

        try
        {
            await _collectionRepository.DeleteCollectionAsync(guidCollectionId);
        }
        catch (Exception)
        {
            return NotFound();
            //TODO: throw not found
        }

        return RedirectToAction(nameof(ShowUserCollections));
    }
}
