namespace CollectionsManagementService.VievModels.Item;

public class ItemViewModel
{
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public List<ItemFieldViewModel<int>> IntegerFields { get; set; }
    public List<ItemFieldViewModel<string>> StringFields { get; set; }
    public List<ItemFieldViewModel<DateOnly>> DateFields { get; set; }
    public List<ItemFieldViewModel<bool>> BoolFields { get; set; }
    public List<ItemFieldViewModel<string>> TextFields { get; set; }
    public DateTime CreationDate { get; set; }
}
