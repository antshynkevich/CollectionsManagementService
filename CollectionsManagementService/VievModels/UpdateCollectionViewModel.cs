namespace CollectionsManagementService.VievModels;

public class UpdateCollectionViewModel
{
    public Guid CollectionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public List<CollectionFieldViewModel> CollectionFields { get; set; }
}
