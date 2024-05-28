using DataORMLayer.EfCoreCode;
using DataORMLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataORMLayer.Repository;

public class CollectionRepository : ICollectionRepository
{
    private readonly AppDbContext _context;

    public CollectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Collection collection)
    {
        await _context.Collections.AddAsync(collection);
        await _context.SaveChangesAsync();
    }

    public Collection Get(Expression<Func<Collection, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Collection>> GetAllAsync()
    {
        return await _context.Collections
            .AsNoTracking()
            .Include(c => c.Category)
            .Include(c => c.CollectionFields)
            .ToListAsync();
    }

    public async Task<Collection?> GetCollectionByIdAsync(Guid collectionId)
    {
        return await _context.Collections
            .AsNoTracking()
            .Include(c => c.CollectionFields)
            .Include(c => c.Category)
            .FirstOrDefaultAsync(c => c.CollectionId == collectionId);
    }

    public async Task<List<Collection>> GetCollectionsByUserIdAsync(string id)
    {
        return await _context.Collections
            .AsNoTracking()
            .Where(c => c.UserId == id)
            .Include(c => c.Category)
            .Include(c => c.CollectionFields)
            .ToListAsync();
    }

    public async Task<Collection?> GetWithItemsByIdAsync(Guid collectionId)
    {
        var collection = await _context.Collections
            .AsNoTracking()
            .Include(coll => coll.Items)
                .ThenInclude(item => item.IntegerFields)
                .ThenInclude(field => field.CollectionField)
            .Include(coll => coll.Items)
                .ThenInclude(item => item.StringFields)
                .ThenInclude(field => field.CollectionField)
            .Include(coll => coll.Items)
                .ThenInclude(item => item.DateFields)
                .ThenInclude(field => field.CollectionField)
            .Include(coll => coll.Items)
                .ThenInclude(item => item.TextFields)
                .ThenInclude(field => field.CollectionField)
            .Include(coll => coll.Items)
                .ThenInclude(item => item.BooleanFields)
                .ThenInclude(field => field.CollectionField)
            .Include(coll => coll.CollectionFields)
            .Include(coll => coll.Category)
            .Include(coll => coll.ApplicationUser)
            .FirstOrDefaultAsync(collection => collection.CollectionId == collectionId);
        return collection;
    }

    public async Task UpdateCollectionAsync(Collection collection)
    {
        var oldCollection = await _context.Collections
            .Include(coll => coll.CollectionFields)
            .FirstOrDefaultAsync(x => x.CollectionId == collection.CollectionId);
        if (oldCollection == null)
            throw new ArgumentException("The collection was not found by Id", nameof(collection));
        oldCollection.Name = collection.Name;
        oldCollection.Description = collection.Description;
        oldCollection.ImageUrl = collection.ImageUrl;
        if (collection.CollectionFields != null)
        {
            foreach (var oldField in oldCollection.CollectionFields)
            {
                var updatedField = collection.CollectionFields.First(x => x.CollectionFieldId == oldField.CollectionFieldId);
                oldField.FieldName = updatedField.FieldName;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteCollectionAsync(Guid collectionId)
    {
        var collection = _context.Collections.FirstOrDefault(x => x.CollectionId == collectionId);
        if (collection == null)
            throw new ArgumentException("The collection was not found by Id", nameof(collectionId));
        _context.Collections.Remove(collection);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Collection>> GetLargestCollectionsAsync(int number = 5)
    {
        return await _context.Collections
            .OrderByDescending(c => c.Items.Count)
            .Take(number)
            .Include(c => c.CollectionFields)
            .Include(c => c.Category)
            .Include(c => c.Items)
            .ToListAsync();
    }

    public async Task<List<Collection>> GetSortedCollectionsAsync(string sortOrder, int? categoryId)
    {
        var collections = _context.Collections.AsQueryable();
        if (categoryId.HasValue)
        {
            collections = collections.Where(c  => c.CategoryId == categoryId);
        }

        collections = sortOrder switch
        {
            "name_desc" => collections.OrderByDescending(c => c.Name),
            "name" => collections.OrderBy(c => c.Name),
            "date" => collections.OrderBy(c => c.CreationDate),
            _ => collections.OrderByDescending(c => c.CreationDate),
        };

        return await collections
            .Include(c => c.CollectionFields)
            .Include(c => c.Category)
            .AsNoTracking()
            .ToListAsync();
    }
}
