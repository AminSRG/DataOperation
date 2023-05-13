using System.Threading.Tasks;
using System.Collections.Generic;
using Base.BaseEntitys.Interfaces;

namespace Base.BaseRepository
{
    public interface IRepository<T> where T :  class
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteByIdAsync(string id);
        void BulkInsert(IEnumerable<T> list);
        Task<bool> ExecuteQueryAsync(string query, object parameters = null);
        Task<IEnumerable<T>> QueryAsync(string where, params object[] parameters);
        Task<IList<T>> GetAllAsync();
    }
}
