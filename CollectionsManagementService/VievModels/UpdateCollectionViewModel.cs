namespace CollectionsManagementService.VievModels;

public class UpdateCollectionViewModel
{
    public Guid CollectionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //public int CategoryId { get; set; }
    // TODO: add category update
    public IFormFile Image { get; set; }
    public string? ImageUrl { get; set; }
    public List<CollectionFieldViewModel> CollectionFields { get; set; }
}
