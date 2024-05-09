using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models.CustomDataFields;

[Table("BooleanFields")]
public class BooleanField
{
    public Guid BooleanFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    [Required]
    public bool Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
