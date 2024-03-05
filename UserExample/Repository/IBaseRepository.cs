using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExample.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetById(string id);
        Task<List<T>> GetAll();
        Task AddAsync(T enity);
        void DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
