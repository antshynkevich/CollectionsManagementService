using System.ComponentModel.DataAnnotations;

namespace DataORMLayer.Models;

public class Collection
{
    public Guid CollectionId { get; set; }
    [Required]
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }

    public Category Category { get; set; }
    public ICollection<Item> Items { get; set; }
    public ICollection<CollectionField> CollectionFields { get; set; }
}
