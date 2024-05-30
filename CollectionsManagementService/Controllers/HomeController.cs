using CollectionsManagementService.Models;
using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CollectionsManagementService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemMapper _itemMapper;
        private readonly ICollectionMapper _collectionMapper;

        public HomeController(ICollectionRepository collectionRepository, IItemRepository itemRepository,
            IItemMapper itemMapper, ICollectionMapper collectionMapper)
        {
            _collectionRepository = collectionRepository;
            _itemRepository = itemRepository;
            _itemMapper = itemMapper;
            _collectionMapper = collectionMapper;
        }

        public async Task<IActionResult> Index()
        {
            var neededCollections = 5;
            var neededItems = 5;
            var largestCollection = await _collectionRepository.GetLargestCollectionsAsync(neededCollections);
            var newestItems = await _itemRepository.GetNewestItemsAsync(neededItems);
            var twoCollections = new HomePageViewModel()
            {
                HomeCollections = largestCollection.Select(c => _collectionMapper.MapToHomeCollectionVM(c)).ToList(),
                HomeItems = newestItems.Select(i => _itemMapper.MapToItemViewModel(i)).ToList(),
            };

            return View(twoCollections);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchStr)
        {
            ViewData["SearchString"] = searchStr;
            var items = await _itemRepository.GetResultFromSearchAsync(searchStr);
            var collections = await _collectionRepository.GetResultFromSearchAsync(searchStr);
            var searchResult = new SearchResultViewModel()
            {
                Items = items.Select(i => _itemMapper.MapToItemFromSearch(i)).ToList(),
                Collections = _collectionMapper.MapToCollectionViewModelList(collections)
            };

            return View(searchResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
