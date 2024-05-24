using CollectionsManagementService.VievModels.Item;

namespace CollectionsManagementService.VievModels.Collection;

public class DetailedCollectionViewModel : UserCollectionViewModel
{
    public string UserName { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public List<ItemViewModel> Items { get; set; }
}
