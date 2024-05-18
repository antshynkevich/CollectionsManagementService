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

    public async Task<List<Collection>> GetCollectionsByUserIdAsync(string id)
    {
        return await _context.Collections
            .AsNoTracking()
            .Where(c => c.UserId == id)
            .Include(c => c.Category)
            .Include(c => c.CollectionFields)
            .ToListAsync();
    }
}
