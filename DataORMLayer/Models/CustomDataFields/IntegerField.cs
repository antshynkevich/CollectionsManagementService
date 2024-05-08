namespace DataORMLayer.Models.CustomDataFields;

public class IntegerField
{
    public Guid IntegerFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    public int Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
