using System.Linq.Expressions;

namespace GYM.DataLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null, bool disableTracking = true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool disableTracking = true);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task InsertAsync(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void DeleteBulk(IEnumerable<T> entities);
        Task<int> ExecuteSqlAsync(string sql, params object[] parameters);
        Task SaveAsync();
    }

}
