using CollectionsManagementService.VievModels;
using DataORMLayer.Models.CustomDataFields;

namespace CollectionsManagementService.Services;

public static class MapItemFieldHelper<T>
{
    public static ItemFieldViewModel<T> MapToItemViewModel(IItemField<T> field)
    {
        return new ItemFieldViewModel<T>
        {
            FieldName = field.CollectionField.FieldName,
            FieldType = field.CollectionField.FieldType.ToString(),
            Value = field.Value
        };
    }
}
