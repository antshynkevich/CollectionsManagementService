using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

[Table("Tags")]
public class Tag
{
    [Key]
    public Guid TagId { get; set; }
    [Required]
    [MaxLength(Constants.TagSize)]
    public string Name { get; set; }

    public ICollection<Item> Items { get; set; }
}
