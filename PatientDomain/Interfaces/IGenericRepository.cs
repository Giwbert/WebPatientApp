using PatientDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDomain.Interfaces
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Update(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetByName(string name);
        IQueryable<T> GetQueryEntity();
    }
}
