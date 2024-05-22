using DataORMLayer.Models;

namespace DataORMLayer.Repository;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid itemId);
    Task CreateItemAsync(Item item);
    Task DeleteItemAsync(Guid itemId);
    Task UpdateItemAsync(Item item);
}
