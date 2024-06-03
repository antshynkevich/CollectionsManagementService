using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;

namespace CollectionsManagementService.VievModels.Collection;

public class DetailedCollectionViewModel : CollectionViewModel, IUserIdContained
{
    public string UserName { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public string? UserId { get; set; }
    public List<ItemViewModel> Items { get; set; } = [];
}
