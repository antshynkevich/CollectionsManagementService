using DataORMLayer.Models;

namespace CollectionsManagementService.VievModels;

public class CreateCollectionViewModel
{
    public CreateCollectionFieldViewModel[] CollectionFields { get; set; } 
        = new CreateCollectionFieldViewModel[3 * 5];
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
}

public class CreateCollectionFieldViewModel
{
    public FieldType FieldType { get; set; }
    public string Name { get; set; }
    public bool IsFieldNeeded { get; set; }
}
