using CollectionsManagementService.VievModels.Collection;
using CollectionsManagementService.VievModels.Item;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services.Interfaces;

public interface ICollectionMapper
{
    Collection MapToCollection(CreateCollectionViewModel collectionVM, string userId);
    Collection MapToCollection(UpdateCollectionViewModel collectionVM);
    UpdateCollectionViewModel MapToUpdateCollectionVM(Collection collection);
    CollectionViewModel MapToCollectionViewModel(Collection collection);
    List<CollectionViewModel> MapToCollectionViewModelList(List<Collection> collections);
    DetailedCollectionViewModel MapToDetailedCollection(Collection collection);
    HomeCollectionViewModel MapToHomeCollectionVM(Collection collection);
}
