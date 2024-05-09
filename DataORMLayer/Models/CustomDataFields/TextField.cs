using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models.CustomDataFields;

[Table("TextFields")]
public class TextField
{
    public Guid TextFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    [Required]
    [MaxLength(512)]
    public string Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
