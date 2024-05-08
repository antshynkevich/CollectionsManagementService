namespace DataORMLayer.Models.CustomDataFields;

public class BooleanField
{
    public Guid BooleanFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    public bool Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
