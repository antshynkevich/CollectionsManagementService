using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

[Table("CollectionFields")]
public class CollectionField
{
    public Guid CollectionFieldId { get; set; }
    public Guid CollectionId { get; set; }
    [Required]
    public string FieldName { get; set; }
    [Required]
    public FieldType FieldType { get; set; }

    public Collection Collection { get; set; }
}
