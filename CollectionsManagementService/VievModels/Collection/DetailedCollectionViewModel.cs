using CollectionsManagementService.VievModels.Item;

namespace CollectionsManagementService.VievModels.Collection;

public class DetailedCollectionViewModel : CollectionViewModel
{
    public string UserName { get; set; }
    public string? ImageUrl { get; set; }
    public List<ItemViewModel> Items { get; set; } = [];
}
