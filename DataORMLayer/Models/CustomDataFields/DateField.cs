using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models.CustomDataFields;

[Table("DateFields")]
public class DateField : IItemField<DateOnly>
{
    public Guid DateFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    [Required]
    [Column(TypeName = "date")]
    public DateOnly Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
