using DataORMLayer.Models.CustomDataFields;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataORMLayer.Models;

public class Item
{
    public Guid ItemId { get; set; }
    [Required]
    [MaxLength(Constants.NameSize)]
    public string Name { get; set; }
    public Guid CollectionId { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime CreationDate { get; set; }

    public Collection Collection { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<IntegerField> IntegerFields { get; set; }
    public ICollection<StringField> StringFields { get; set; }
    public ICollection<TextField> TextFields { get; set; }
    public ICollection<BooleanField> BooleanFields { get; set; }
    public ICollection<DateField> DateFields { get; set; }
    public ICollection<UserComment> UserComments { get; set; }
    public ICollection<UserLike> UserLikes { get; set; }
}
