using Sazman.DataModels.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Sazman.API.Dao
{
    public abstract class BaseDao<T> : IBaseDao<T> where T: class
    {
        protected SazmanContext _context { get; set; }

        public BaseDao(SazmanContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(Guid id, T entity)
        {
            var item = _context.Set<T>().Find(id);
            _context.Entry(item).CurrentValues.SetValues(entity);
        }

        public void Delete(T entity) => _context.Entry(entity).State = EntityState.Deleted;
    }
}
