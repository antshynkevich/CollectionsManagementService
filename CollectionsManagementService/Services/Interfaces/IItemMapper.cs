using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services.Interfaces;

public interface IItemMapper
{
    DetailedItemViewModel MapToItemViewModel(Item item);
    CreateItemViewModel MapToCreateItemViewModel(Collection collection);
    Item MapToItem(CreateItemViewModel viewModel);
}
