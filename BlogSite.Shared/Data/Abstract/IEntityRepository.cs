using BlogSite.Shared.Entities.Abstract;
using System.Linq.Expressions;

//this class use for all frameworks
namespace BlogSite.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //multi include
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task <bool> AnyAsnyc(Expression<Func<T, bool>> predicate);
        Task <int> CountAsnyc(Expression<Func<T, bool>> predicate);

    }
}
