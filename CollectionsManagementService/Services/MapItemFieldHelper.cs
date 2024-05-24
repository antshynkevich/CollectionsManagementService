using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;
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

    public static List<ItemFieldWithIdViewModel<T>> MapToItemFields(ICollection<CollectionField> collectionFields, FieldType fieldType)
    {
        return collectionFields
            .Where(x => x.FieldType == fieldType)
            .Select(x => new ItemFieldWithIdViewModel<T>
            {
                FieldName = x.FieldName,
                FieldType = x.FieldType.ToString(),
                CollectionFieldId = x.CollectionFieldId
            }).ToList();
    }
}
