namespace DataORMLayer.Models.CustomDataFields;

public class TextField
{
    public Guid TextFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    public string Value { get; set; }

    public Collection Collection { get; set; }
    public Item Item { get; set; }
}
