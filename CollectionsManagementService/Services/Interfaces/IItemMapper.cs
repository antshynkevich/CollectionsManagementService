using CollectionsManagementService.VievModels;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services.Interfaces;

public interface IItemMapper
{
    DetailedItemViewModel MapToItemViewModel(Item item);
}
