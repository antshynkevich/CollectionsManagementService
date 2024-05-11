using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

[Table("Categories")]
public class Category
{
    public int CategoryId { get; set; }
    [Required]
    [MaxLength(64)]
    public string Name { get; set; }

    public ICollection<Collection> Collections { get; set; }
}
