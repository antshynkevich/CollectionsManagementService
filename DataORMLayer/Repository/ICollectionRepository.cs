using DataORMLayer.Models;
using System.Linq.Expressions;

namespace DataORMLayer.Repository;

public interface ICollectionRepository
{
    Task<List<Collection>> GetAllAsync();
    Task<List<Collection>> GetCollectionsByUserIdAsync(string id);
    Task AddAsync(Collection collection);
    Collection Get(Expression<Func<Collection, bool>> filter);
}
