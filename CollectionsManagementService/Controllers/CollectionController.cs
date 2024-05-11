using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CollectionsManagementService.Controllers;

public class CollectionController : Controller
{
    private readonly IRepository<Collection> _collectionRepository;

    public CollectionController(IRepository<Collection> collectionRepository)
    {
        _collectionRepository = collectionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var collectionsWithFields = await _collectionRepository.GetAllAsync();
        return View(collectionsWithFields);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var viewModel = new CreateCollectionViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateCollectionViewModel viewModel)
    {
        var collection = viewModel.MapToCollection();
        _collectionRepository.AddAsync(collection);
        return RedirectToAction("Index");
    }
}
