using CollectionsManagementService.VievModels;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services;

public interface IModelMapper
{
    Collection MapToCollection(CreateCollectionViewModel collectionVM, string userId);
    Collection MapToCollection(UpdateCollectionViewModel collectionVM);
    UpdateCollectionViewModel MapToUpdateCollectionVM(Collection collection);
    UserCollectionViewModel MapToCollectionViewModel(Collection collection);
    List<UserCollectionViewModel> MapToCollectionViewModelList(List<Collection> collections);
    DetailedCollectionViewModel MapToDetailedCollection(Collection collection);
    ItemViewModel MapToItemViewModel(Item item);
}
