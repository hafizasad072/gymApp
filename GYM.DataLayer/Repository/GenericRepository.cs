using GYM.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GYM.DataLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MuscleUpGYMContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(MuscleUpGYMContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>>? include = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet; // Return all
            }

            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (disableTracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _dbSet.ToListAsync();
            }

            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<int> ExecuteSqlAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void DeleteBulk(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }
    }

}
