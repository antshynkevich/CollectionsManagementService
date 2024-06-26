﻿using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services.Interfaces;

public interface IItemMapper
{
    DetailedItemViewModel MapToDetailedItemViewModel(Item item);
    CreateItemViewModel MapToCreateItemViewModel(Collection collection);
    Item MapToItem(CreateItemViewModel viewModel);
    Item MapToItem(UpdateItemViewModel viewModel);
    ItemViewModel MapToItemViewModel(Item item);
    ItemSearchPageViewModel MapToItemFromSearch(Item item);
    UpdateItemViewModel MapToUpdateItemViewModel(Item item);
}
