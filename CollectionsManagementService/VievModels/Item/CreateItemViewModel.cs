using DataORMLayer;
using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels.Item;

public class CreateItemViewModel
{
    public Guid CollectionId { get; set; }
    [Required]
    [MaxLength(Constants.NameSize)]
    public string Name { get; set; }
    public List<ItemFieldWithIdViewModel<int>> IntegerFields { get; set; }
    public List<ItemFieldWithIdViewModel<string>> StringFields { get; set; }
    public List<ItemFieldWithIdViewModel<DateOnly>> DateFields { get; set; }
    public List<ItemFieldWithIdViewModel<bool>> BoolFields { get; set; }
    public List<ItemFieldWithIdViewModel<string>> TextFields { get; set; }
}

public class ItemFieldWithIdViewModel<T> : ItemFieldViewModel<T>
{
    public Guid CollectionFieldId { get; set; }
}
