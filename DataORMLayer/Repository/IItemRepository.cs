using DataORMLayer.Models;

namespace DataORMLayer.Repository;

public interface IItemRepository
{
    Task<Item?> GetByIdAsync(Guid itemId);
    Task DeleteItemAsync(Guid itemId);
    Task UpdateItemAsync(Item item);
    Task AddItemAsync(Item item);
    Task<List<Item>> GetNewestItemsAsync(int number = 5);
    Task<List<Item>> GetResultFromSearchAsync(string searchString);
    Task<Collection> GetCollectionDataByItemIdAsync(Guid itemId);
}
