using DataORMLayer.Models;

namespace CollectionsManagementService.VievModels;

public class CollectionFieldViewModel
{
    public Guid FieldId { get; set; }
    public string FieldName { get; set; }
    public string FieldTypeName { get; set; }
    public FieldType FieldType { get; set; }
    public bool IsFieldNeeded { get; set; }
}
