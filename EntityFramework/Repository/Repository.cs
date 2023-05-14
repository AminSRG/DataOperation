using Base.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework.Repository
{
    public abstract class Repository<T> : object, IRepository<T> where T : class
    {
        protected internal Repository(DbContext databaseContext) : base()
        {
            DatabaseContext = databaseContext;

            DbSet = DatabaseContext.Set<T>();
        }


        protected DbSet<T> DbSet { get; }
        protected DbContext DatabaseContext { get; }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            var response = await DbSet.AddAsync(entity);

            SaveAsync();

            if (response == null) return false;

            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            EntityEntry<T>? response = null;
            await Task.Run(() =>
            {
                response = DbSet.Update(entity);
            });

            SaveAsync();

            if (response == null) return false;

            return true;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            EntityEntry<T>? response = null;
            await Task.Run(() =>
            {
                response = DbSet.Remove(entity);
            });

            SaveAsync();

            if (response == null) return false;

            return true;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(keyValues: id);
        }

        public virtual async Task<bool> DeleteByIdAsync(string id)
        {
            T entity =
                await GetByIdAsync(id);

            if (entity == null) return false;

            return await DeleteAsync(entity);
        }

        public void BulkInsert(IEnumerable<T> list)
        {
            DatabaseContext.BulkInsert(list);

            SaveAsync();

        }

        public async Task<bool> ExecuteQueryAsync(string query, object parameters = null)
        {
            IQueryable<T>? result = null;
            await Task.Run(() =>
            {
                result = DbSet.FromSqlRaw(sql: query, parameters: parameters);
            });

            SaveAsync();

            if (result is null)
                return false;
            return true;
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var result =
                await
                DbSet.ToListAsync();

            return result;
        }

        public virtual async Task<IEnumerable<T>> QueryAsync(string where, params object[] parameters)
        {
            IQueryable<T>? result = null;
            await Task.Run(() =>
            {
                result = DbSet.FromSqlRaw(sql: where, parameters: parameters);
            });

            SaveAsync();

            return result;
        }

        private async Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
