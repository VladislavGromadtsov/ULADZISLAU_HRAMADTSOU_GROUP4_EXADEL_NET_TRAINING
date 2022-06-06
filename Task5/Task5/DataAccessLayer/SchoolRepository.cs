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

        public async Task CreateAsync(T item)
        {
            await _appContext.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _appContext.FindAsync<T>(id);
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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _appContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetItemAsync(int id)
        {
            var item = await _appContext.FindAsync<T>(id);

            return item;
        }

        public async Task SaveAsync()
        {
            await _appContext.SaveChangesAsync();
        }

        public void Update(T item)
        {
            _appContext.Entry(item).State = EntityState.Modified;
        }
    }
}
