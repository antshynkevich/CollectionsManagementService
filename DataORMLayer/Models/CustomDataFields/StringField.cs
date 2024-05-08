namespace DataORMLayer.Models.CustomDataFields;

public class StringField
{
    public Guid StringFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    public string Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
