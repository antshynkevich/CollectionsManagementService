using System.Linq.Expressions;

namespace DataORMLayer.Repository;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T collection);
    T Get(Expression<Func<T, bool>> filter);
}
