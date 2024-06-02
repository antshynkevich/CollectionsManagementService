﻿using DataORMLayer.Models;

namespace CollectionsManagementService.VievModels.Item;

public class DetailedItemViewModel : ItemViewModel, IUserIdContained
{
    public string UserId { get; set; }
    public Guid CollectionId { get; set; }
    public string CollectionName { get; set; }
}
