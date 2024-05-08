namespace DataORMLayer.Models;

public class CollectionField
{
    public Guid CollectionFieldId { get; set; }
    public Guid CollectionId { get; set; }
    public string Title { get; set; }

    public Collection Collection { get; set; }
}
