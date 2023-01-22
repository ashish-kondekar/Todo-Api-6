using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TODO.BLL.IRepositories;
using TODO.Domain.Entities;

namespace TODO.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TodoDbContext _todoDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
            _dbSet = todoDbContext.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "{repo} failed to fetch", typeof(T));
                throw;
            }
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
                                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                      string includeProperties = "")
        {
            try
            {
                return await Query(filter, orderBy, includeProperties).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<T> GetOne(Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            string includeProperties = "")
        {
            try
            {
                return await Query(filter, orderBy, includeProperties).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        private IQueryable<T> Query(Expression<Func<T, bool>> filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }
                else
                {
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
