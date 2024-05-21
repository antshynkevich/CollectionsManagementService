namespace CollectionsManagementService.VievModels;

public class DetailedCollectionViewModel : UserCollectionViewModel
{
    public string UserName { get; set; }
    public string Description { get; set; }
    public List<ItemViewModel> Items { get; set; }
}
