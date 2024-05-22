namespace CollectionsManagementService.VievModels;

public class DetailedItemViewModel : ItemViewModel
{
    public string UserName { get; set; }
    public Guid CollectionId { get; set; }
    public string CollectionName { get; set; }
}
