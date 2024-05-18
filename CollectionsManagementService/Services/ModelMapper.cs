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

    public UserCollectionViewModel MapToCollectionViewModel(Collection collection)
    {
        var collectionVM = new UserCollectionViewModel
        {
            CollectionId = collection.CollectionId,
            CollectionName = collection.Name,
            Description = collection.Description,
            CategoryName = collection.Category.Name
        };

        foreach (var customField in collection.CollectionFields)
        {
            var customFieldVM = new CollectionFieldViewModel
            {
                FieldName = customField.FieldName,
                FildTypeName = customField.FieldType.ToString()
            };

            collectionVM.CustomCollectionFields.Add(customFieldVM);
        }

        return collectionVM;
    }

    public List<UserCollectionViewModel> MapToCollectionViewModelList(List<Collection> collections)
    {
        return collections.Select(MapToCollectionViewModel).ToList();
    }
}
