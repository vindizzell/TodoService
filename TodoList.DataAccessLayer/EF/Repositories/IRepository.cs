using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DataAccessLayer.EF.Model.Base;

namespace TodoList.DataAccessLayer.EF.Repositories
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(long id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T id);
    }
}