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

    public async Task<Collection> GetCollectionDataByItemIdAsync(Guid itemId)
    {
        var item = await _context.Items
            .AsNoTracking()
            .Include(x => x.Collection)
            .FirstOrDefaultAsync(x => x.ItemId == itemId);

        if (item == null) 
            throw new ArgumentException("The collection was not found by Id", nameof(itemId));

        return item.Collection;
    }

    public async Task DeleteItemAsync(Guid itemId)
    {
        var item = await _context.Items
            .Include(i => i.DateFields)
            .Include(i => i.BooleanFields)
            .Include(i => i.IntegerFields)
            .Include(i => i.TextFields)
            .Include(i => i.StringFields)
            .FirstOrDefaultAsync(x => x.ItemId == itemId);
        if (item == null)
            throw new ArgumentException("The collection was not found by Id", nameof(itemId));
        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
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
        var oldItem = await _context.Items
            .Include(i => i.DateFields)
            .Include(i => i.BooleanFields)
            .Include(i => i.TextFields)
            .Include(i => i.StringFields)
            .Include(i => i.IntegerFields)
            .FirstOrDefaultAsync(i => i.ItemId == item.ItemId);

        if (oldItem == null)
            throw new ArgumentException("The item was not found by Id", nameof(item));
        
        oldItem.Name = item.Name;

        foreach (var field in item.DateFields)
        {
            var oldField = oldItem.DateFields.FirstOrDefault(x => x.DateFieldId == field.DateFieldId);
            if (oldField != null)
                oldField.Value = field.Value;
        }

        foreach (var field in item.StringFields)
        {
            var oldField = oldItem.StringFields.FirstOrDefault(x => x.StringFieldId == field.StringFieldId);
            if (oldField != null)
                oldField.Value = field.Value;
        }

        foreach (var field in item.TextFields)
        {
            var oldField = oldItem.TextFields.FirstOrDefault(x => x.TextFieldId == field.TextFieldId);
            if (oldField != null)
                oldField.Value = field.Value;
        }

        foreach (var field in item.IntegerFields)
        {
            var oldField = oldItem.IntegerFields.FirstOrDefault(x => x.IntegerFieldId == field.IntegerFieldId);
            if (oldField != null)
                oldField.Value = field.Value;
        }

        foreach (var field in item.BooleanFields)
        {
            var oldField = oldItem.BooleanFields.FirstOrDefault(x => x.BooleanFieldId == field.BooleanFieldId);
            if (oldField != null)
                oldField.Value = field.Value;
        }

        await _context.SaveChangesAsync();
    }
}
