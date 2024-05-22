using CollectionsManagementService.VievModels;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services;

public class ItemMapper : IItemMapper
{
    public DetailedItemViewModel MapToItemViewModel(Item item)
    {
        return new DetailedItemViewModel
        {
            ItemId = item.ItemId,
            ItemName = item.Name,
            CollectionId = item.CollectionId,
            CollectionName = item.Collection.Name,
            IntegerFields = item.IntegerFields.Select(MapItemFieldHelper<int>.MapToItemViewModel).ToList(),
            BoolFields = item.BooleanFields.Select(MapItemFieldHelper<bool>.MapToItemViewModel).ToList(),
            DateFields = item.DateFields.Select(MapItemFieldHelper<DateOnly>.MapToItemViewModel).ToList(),
            StringFields = item.StringFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
            TextFields = item.TextFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
        };
    }
}
