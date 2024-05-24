namespace CollectionsManagementService.VievModels.Collection;

public class UserCollectionViewModel
{
    public Guid CollectionId { get; set; }
    public string CollectionName { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public List<CollectionFieldViewModel> CustomCollectionFields { get; set; } = [];
}
