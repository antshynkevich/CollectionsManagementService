using DataORMLayer;
using DataORMLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace CollectionsManagementService.VievModels;

public class CollectionFieldViewModel
{
    public Guid FieldId { get; set; }
    [MaxLength(Constants.NameSize)]
    public string FieldName { get; set; }
    public string FieldTypeName { get; set; }
    public FieldType FieldType { get; set; }
    public bool IsFieldNeeded { get; set; }
}
