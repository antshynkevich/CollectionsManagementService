namespace CollectionsManagementService.VievModels;

public class ItemViewModel
{
    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public List<ItemFieldViewModel<int>> IntegerFields { get; set; }
    public List<ItemFieldViewModel<string>> StringFields { get; set; }
    public List<ItemFieldViewModel<DateOnly>> DateFields { get; set; }
    public List<ItemFieldViewModel<bool>> BoolFields { get; set; }
    public List<ItemFieldViewModel<string>> TextFields { get; set; }
}

public class ItemFieldViewModel<T>
{
    public string FieldName { get; set; }
    public string FieldType { get; set; }
    public T Value { get; set; }
}
