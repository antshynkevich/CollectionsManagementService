using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels.Item;

public class ItemFieldViewModel<T>
{
    public string FieldName { get; set; }
    public string FieldType { get; set; }
    [Required(ErrorMessage = "Value of the field is required")]
    public T Value { get; set; }
}
