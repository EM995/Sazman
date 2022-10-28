using System.Linq.Expressions;

namespace Sazman.API.Dao
{
    public interface IBaseDao<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(Guid id, T entity);
        void Delete(T entity);
    }
}
