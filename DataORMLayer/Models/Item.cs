using DataORMLayer.Models.CustomDataFields;

namespace DataORMLayer.Models;

public class Item
{
    public Guid ItemId { get; set; }
    public string Title { get; set; }
    public Guid CollectionId { get; set; }

    public Collection Collection { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<IntegerField> IntegerFields { get; set; }
    public ICollection<StringField> StringFields { get; set; }
    public ICollection<TextField> TextFields { get; set; }
    public ICollection<BooleanField> BooleanFields { get; set; }
    public ICollection<DateField> DateFields { get; set; }
}
