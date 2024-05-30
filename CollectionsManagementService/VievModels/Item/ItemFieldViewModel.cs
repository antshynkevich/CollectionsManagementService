namespace CollectionsManagementService.VievModels.Item;

public class ItemFieldViewModel<T>
{
    public string FieldName { get; set; }
    public string FieldType { get; set; }
    public T Value { get; set; }
}
