using ERPProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERPProject.Data.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> Get(Guid id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}
