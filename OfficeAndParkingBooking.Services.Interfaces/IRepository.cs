namespace OfficeAndParkingBooking.Services.Interfaces
{
    using System.Linq.Expressions;

    public interface IRepository : IDisposable
    {
        IQueryable<T> AllAsQueryable<T>(Expression<Func<T, bool>>? filter = null, bool tracked = true) where T : class;

        Task<IEnumerable<T>> AllAsync<T>(Expression<Func<T, bool>>? filter = null, bool tracked = true) where T : class;

        Task<T?> FindByIdAsync<T>(int id) where T : class;

        Task<T?> FindByIdAsync<T>(string id) where T : class;

        Task AddAsync<T>(T entity) where T : class;

        void AddRange<T>(IEnumerable<T> entities) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteMany<T>(Expression<Func<T, bool>> predicate) where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}