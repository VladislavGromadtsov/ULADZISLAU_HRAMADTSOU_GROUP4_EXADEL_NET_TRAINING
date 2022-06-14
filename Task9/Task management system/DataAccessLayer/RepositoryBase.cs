using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task_management_system.Context;

namespace Task_management_system.DataAccessLayer
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected ApplicationContext _context;
        public RepositoryBase(ApplicationContext context)
        {
            this._context = context;
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindAll() =>
            _context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
