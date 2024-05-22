using CollectionsManagementService.VievModels;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services;

public interface IItemMapper
{
    DetailedItemViewModel MapToItemViewModel(Item item);
}
