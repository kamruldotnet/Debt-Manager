using DebtManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DebtManager.Core.Interfaces
{
    public interface IAsyncRepository<T> where T: Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
