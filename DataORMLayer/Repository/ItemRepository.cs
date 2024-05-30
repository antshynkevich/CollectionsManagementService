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

    public async Task<List<Item>> GetResultFromSearchAsync(string searchString)
    {
        var tagsItems = await _context.Tags
            .Where(t => EF.Functions.Contains(t.Name, $"\"{searchString}\""))
            .Include(t => t.Items)
            .Select(t => t.Items)
            .ToListAsync();
        
        var allitemIds = new List<Guid>();
        foreach (var items in tagsItems)
        {
            allitemIds.AddRange(items.Select(i => i.ItemId));
        }

        var itemsByNameIds = await _context.Items
            .Where(i => EF.Functions.FreeText(i.Name, $"\"{searchString}\""))
            .Select(i => i.ItemId)
            .ToListAsync();
        var commentsIds = await _context.UserComments
            .Where(c => EF.Functions.FreeText(c.CommentText, $"\"{searchString}\""))
            .Select(c => c.ItemId)
            .ToListAsync();
        var textFieldsIds = await _context.TextFields
            .Where(c => EF.Functions.FreeText(c.Value, $"\"{searchString}\""))
            .Select(c => c.ItemId)
            .ToListAsync();
        var stringFieldsIds = await _context.StringFields
            .Where(c => EF.Functions.FreeText(c.Value, $"\"{searchString}\""))
            .Select (c => c.ItemId)
            .ToListAsync();

        allitemIds.AddRange(itemsByNameIds);
        allitemIds.AddRange(commentsIds);
        allitemIds.AddRange(textFieldsIds);
        allitemIds.AddRange(stringFieldsIds);
        var uniqueIds = allitemIds.Distinct().ToList();

        var data = await _context.Items
            .Where(i => uniqueIds.Contains(i.ItemId))
            .Include(i => i.Collection)
            .Include(i => i.StringFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.TextFields)
                .ThenInclude(f => f.CollectionField)
            .Include(i => i.Tags)
            .OrderByDescending(i => i.CreationDate)
            .AsNoTracking()
            .ToListAsync();

        return data;
    }

    public async Task UpdateItemAsync(Item item)
    {
        throw new NotImplementedException();
    }
}
