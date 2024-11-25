namespace OfficeAndParkingBooking.Services
{
    using Data;
    using Interfaces;

    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository : IRepository, IDisposable
    {
        private readonly OfficeAndParkingBookingDbContext _context;
        private bool _disposed = false;

        public Repository(OfficeAndParkingBookingDbContext context)
        {
            _context = context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public async Task AddAsync<T>(T entity) where T : class
            => await DbSet<T>().AddAsync(entity);

        public void AddRange<T>(IEnumerable<T> entities) where T : class
            => DbSet<T>().AddRange(entities);

        public IQueryable<T> AllAsQueryable<T>(Expression<Func<T, bool>>? filter = null, bool tracked = true) where T : class
        {
            var query = DbSet<T>().AsQueryable();

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            return tracked ? query : query.AsNoTracking();
        }

        public async Task<IEnumerable<T>> AllAsync<T>(Expression<Func<T, bool>>? filter = null, bool tracked = true) where T : class
        {
            var query = DbSet<T>().AsQueryable();

            if (filter is not null)
            {
                query = query.Where(filter);
            }

            return tracked ? await query.ToListAsync() : await query.AsNoTracking().ToListAsync();
        }

        public void Delete<T>(T entity) where T : class
            => DbSet<T>().Remove(entity);

        public void DeleteMany<T>(Expression<Func<T, bool>> predicate) where T : class
            => DbSet<T>().RemoveRange(DbSet<T>().Where(predicate));

        public async Task<T?> FindByIdAsync<T>(int id) where T : class
            => await DbSet<T>().FindAsync(id);

        public async Task<T?> FindByIdAsync<T>(string id) where T : class
            => await DbSet<T>().FindAsync(id);

        public int SaveChanges()
            => _context.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public void Update<T>(T entity) where T : class
        {
            var entry = _context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                DbSet<T>().Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}