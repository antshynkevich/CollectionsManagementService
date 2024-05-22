using CollectionsManagementService.VievModels;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services;

public class ModelMapper : IModelMapper
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
            CategoryId = int.Parse(collectionVM.CategoryId),
            UserId = userId,
            CollectionFields = collectionFields
        };

        return collection;
    }

    public Collection MapToCollection(UpdateCollectionViewModel collectionVM)
    {
        return new Collection()
        {
            CollectionId = collectionVM.CollectionId,
            Name = collectionVM.Name,
            Description = collectionVM.Description,
            CollectionFields = collectionVM.CollectionFields.Select(x => new CollectionField
            {
                CollectionFieldId = x.FieldId,
                FieldName = x.FieldName
            }).ToList()
        };
    }

    public UserCollectionViewModel MapToCollectionViewModel(Collection collection)
    {
        var collectionVM = new UserCollectionViewModel
        {
            CollectionId = collection.CollectionId,
            CollectionName = collection.Name,
            Description = collection.Description,
            CategoryName = collection.Category.Name,
            CustomCollectionFields = collection.CollectionFields
            .Select(f => new CollectionFieldViewModel
            {
                FieldName = f.FieldName,
                FildTypeName = f.FieldType.ToString()
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
                .Select(x => new CollectionFieldViewModel { FieldName = x.FieldName, FieldId = x.CollectionFieldId, FildTypeName = x.FieldType.ToString() }).ToList(),
            Description = collection.Description,
            Name = collection.Name,
            CategoryId = collection.CategoryId
        };
    }

    public List<UserCollectionViewModel> MapToCollectionViewModelList(List<Collection> collections)
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
            UserName = collection.ApplicationUser.UserName,
            CustomCollectionFields = collection.CollectionFields
                .Select(f => new CollectionFieldViewModel { FieldName = f.FieldName, FildTypeName = f.FieldType.ToString() }).ToList(),
            Items = collection.Items
                .Select(MapToItemViewModel).ToList(),
        };

        return detailedViewModel;
    }

    public ItemViewModel MapToItemViewModel(Item item)
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
}
