using DataORMLayer.EfCoreCode;
using DataORMLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataORMLayer.Repository;

public class CategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }
}
