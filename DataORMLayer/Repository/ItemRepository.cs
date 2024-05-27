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

    public async Task AddItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
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

    public async Task<List<Item>> GetNewestItemsAsync(int number = 5)
    {
        return await _context.Items
            .OrderByDescending(i => i.CreationDate)
            .Take(number)
            .Include (i => i.Collection)
            .Include (i => i.IntegerFields)
            .Include(i => i.StringFields)
            .Include(i => i.BooleanFields)
            .Include(i => i.DateFields)
            .Include(i => i.TextFields)
            .ToListAsync();
    }

    public async Task UpdateItemAsync(Item item)
    {
        throw new NotImplementedException();
    }
}
