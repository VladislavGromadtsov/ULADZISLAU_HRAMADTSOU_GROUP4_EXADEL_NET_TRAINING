using Microsoft.EntityFrameworkCore;
using Task5.Models;

namespace Task5.DataAccessLayer
{
    public class SchoolRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _appContext;
        private bool _disposed = false;
        public SchoolRepository(ApplicationContext applicationContext)
        {
            this._appContext = applicationContext;
        }

        public void Create(T item)
        {
            _appContext.Add(item);
        }

        public void Delete(int id)
        {
            var item = _appContext.Find<T>(id);
            if (item is not null)
            {
                _appContext.Remove(item);
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _appContext.Dispose();
                }

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            return _appContext.Set<T>().ToList();
        }

        public T? GetItem(int id)
        {
            var item = _appContext.Find<T>(id);

            return item;
        }

        public void Save()
        {
            _appContext.SaveChanges();
        }

        public void Update(T item)
        {
            _appContext.Entry(item).State = EntityState.Modified;
        }
    }
}
