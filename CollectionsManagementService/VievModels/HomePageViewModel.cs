using CollectionsManagementService.VievModels.Collection;
using CollectionsManagementService.VievModels.Item;

namespace CollectionsManagementService.VievModels;

public class HomePageViewModel
{
    public List<HomeCollectionViewModel> HomeCollections { get; set; }
    public List<ItemViewModel> HomeItems { get; set; }
}
