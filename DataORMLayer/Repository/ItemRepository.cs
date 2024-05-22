using DataORMLayer.EfCoreCode;
using DataORMLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataORMLayer.Repository;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _context;

    public ItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateItemAsync(Item item)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteItemAsync(Guid itemId)
    {
        throw new NotImplementedException();
    }

    public async Task<Item?> GetByIdAsync(Guid itemId)
    {
        return await _context.Items
            .AsNoTracking()
            .Include(i => i.Collection)
                .ThenInclude(c => c.ApplicationUser)
            .Include(i => i.IntegerFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.StringFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.DateFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.TextFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.BooleanFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.Tags)
            .FirstOrDefaultAsync(c => c.ItemId == itemId);
    }

    public async Task UpdateItemAsync(Item item)
    {
        throw new NotImplementedException();
    }
}
