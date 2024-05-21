
namespace DataORMLayer.Models.CustomDataFields
{
    public interface IItemField<T>
    {
        CollectionField CollectionField { get; set; }
        T Value { get; set; }
    }
}
