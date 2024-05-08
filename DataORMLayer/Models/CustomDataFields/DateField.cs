namespace DataORMLayer.Models.CustomDataFields;

public class DateField
{
    public Guid DateFieldId { get; set; }
    public Guid CollectionFieldId { get; set; }
    public Guid ItemId { get; set; }
    public DateTime Value { get; set; }

    public CollectionField CollectionField { get; set; }
    public Item Item { get; set; }
}
