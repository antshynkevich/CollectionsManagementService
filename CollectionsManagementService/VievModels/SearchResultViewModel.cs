using CollectionsManagementService.VievModels.Collection;
using CollectionsManagementService.VievModels.Item;

namespace CollectionsManagementService.VievModels;

public class SearchResultViewModel
{
    public List<ItemSearchPageViewModel> Items { get; set; }
    public List<CollectionViewModel> Collections { get; set; }
}
