using CollectionsManagementService.VievModels;
using DataORMLayer.Models;

namespace CollectionsManagementService.Services;

public interface IModelMapper
{
    Collection MapToCollection(CreateCollectionViewModel collectionVM, string userId);
    //Collection MapToCollection(UserCollectionViewModel viewModel);
    UserCollectionViewModel MapToCollectionViewModel(Collection collection);
    List<UserCollectionViewModel> MapToCollectionViewModelList(List<Collection> collections);
}
