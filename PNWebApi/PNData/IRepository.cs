using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNData
{
    public interface IRepository
    {

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetEntityAsync<T>(Guid id);

        Task<T> AddEntityAsync<T>(Guid id, T entity);

        Task<T> UpdateEntityAsync<T>(Guid id, T entity);

        Task<T> DeleteEntityAsync<T>(Guid id);

    }
}
