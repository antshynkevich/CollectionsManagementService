namespace CollectionsManagementService.VievModels.Item;

public class ItemSearchPageViewModel
{
    public Guid CollectionId { get; set; }
    public Guid ItemId { get; set; }
    public string Name { get; set; }
    public string CollectionName { get; set; }
    public DateTime CreationDate { get; set; }
    public List<ItemFieldViewModel<string>> StringFields { get; set; }
    public List<ItemFieldViewModel<string>> TextFields { get; set; }
}
