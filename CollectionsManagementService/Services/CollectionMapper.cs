using CollectionsManagementService.Services.Interfaces;
using CollectionsManagementService.VievModels;
using CollectionsManagementService.VievModels.Collection;
using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services;

public class CollectionMapper : ICollectionMapper
{
    public Collection MapToCollection(CreateCollectionViewModel collectionVM, string userId)
    {
        var collectionId = Guid.NewGuid();
        var collectionFields = collectionVM.CollectionFields
            .Where(f => f.IsFieldNeeded)
            .Select(f => new CollectionField
            {
                CollectionFieldId = Guid.NewGuid(),
                CollectionId = collectionId,
                FieldName = f.FieldName,
                FieldType = f.FieldType
            }).ToArray();
        var collection = new Collection()
        {
            CollectionId = collectionId,
            Name = collectionVM.Name,
            Description = collectionVM.Description,
            CreationDate = DateTime.UtcNow,
            ImageUrl = collectionVM.ImageUrl,
            CategoryId = collectionVM.CategoryId,
            UserId = userId,
            CollectionFields = collectionFields
        };

        return collection;
    }

    public Collection MapToCollection(UpdateCollectionViewModel collectionVM)
    {
        var collection = new Collection()
        {
            CollectionId = collectionVM.CollectionId,
            Name = collectionVM.Name,
            Description = collectionVM.Description,
            ImageUrl= collectionVM.ImageUrl
        };

        collection.CollectionFields = collectionVM.CollectionFields.Select(x => new CollectionField
        {
            CollectionFieldId = x.FieldId,
            FieldName = x.FieldName
        }).ToList();

        return collection;
    }

    public CollectionViewModel MapToCollectionViewModel(Collection collection)
    {
        var collectionVM = new CollectionViewModel
        {
            CollectionId = collection.CollectionId,
            CollectionName = collection.Name,
            Description = collection.Description,
            CategoryName = collection.Category.Name,
            CreationDate = collection.CreationDate,
            CustomCollectionFields = collection.CollectionFields
            .Select(f => new CollectionFieldViewModel
            {
                FieldName = f.FieldName,
                FieldTypeName = f.FieldType.ToString()
            }).ToList()
        };

        return collectionVM;
    }

    public UpdateCollectionViewModel MapToUpdateCollectionVM(Collection collection)
    {
        return new UpdateCollectionViewModel
        {
            CollectionId = collection.CollectionId,
            CollectionFields = collection.CollectionFields
                .Select(x => new CollectionFieldViewModel 
                {
                    FieldName = x.FieldName, 
                    FieldId = x.CollectionFieldId, 
                    FieldTypeName = x.FieldType.ToString()
                }).ToList(),
            Description = collection.Description,
            Name = collection.Name,
            ImageUrl = collection.ImageUrl
            //CategoryId = collection.CategoryId
        };
    }

    public List<CollectionViewModel> MapToCollectionViewModelList(List<Collection> collections)
    {
        return collections.Select(MapToCollectionViewModel).ToList();
    }

    public DetailedCollectionViewModel MapToDetailedCollection(Collection collection)
    {
        var detailedViewModel = new DetailedCollectionViewModel()
        {
            CollectionName = collection.Name,
            Description = collection.Description,
            CategoryName = collection.Category.Name,
            UserName = collection.ApplicationUser?.UserName ?? "default username",
            ImageUrl = collection.ImageUrl,
            CollectionId = collection.CollectionId,
            CreationDate = collection.CreationDate,
            UserId = collection.UserId,
            CustomCollectionFields = collection.CollectionFields
                .Select(f => new CollectionFieldViewModel
                {
                    FieldName = f.FieldName,
                    FieldTypeName = f.FieldType.ToString()
                }).ToList(),
            Items = collection.Items
                .Select(MapToItemViewModel).ToList(),
        };

        return detailedViewModel;
    }

    private ItemViewModel MapToItemViewModel(Item item)
    {
        return new ItemViewModel
        {
            ItemId = item.ItemId,
            ItemName = item.Name,
            IntegerFields = item.IntegerFields.Select(MapItemFieldHelper<int>.MapToItemViewModel).ToList(),
            BoolFields = item.BooleanFields.Select(MapItemFieldHelper<bool>.MapToItemViewModel).ToList(),
            DateFields = item.DateFields.Select(MapItemFieldHelper<DateOnly>.MapToItemViewModel).ToList(),
            StringFields = item.StringFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
            TextFields = item.TextFields.Select(MapItemFieldHelper<string>.MapToItemViewModel).ToList(),
        };
    }

    public HomeCollectionViewModel MapToHomeCollectionVM(Collection collection)
    {
        return new HomeCollectionViewModel
        {
            CollectionId = collection.CollectionId,
            CollectionName = collection.Name,
            Description = collection.Description,
            CategoryName = collection.Category.Name,
            ItemsNumber = collection.Items.Count,
            CustomCollectionFields = collection.CollectionFields
            .Select(f => new CollectionFieldViewModel
            {
                FieldName = f.FieldName,
                FieldTypeName = f.FieldType.ToString()
            }).ToList()
        };
    }
}
