using PatientApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Interface
{
    public interface IService<T> where T: PatientViewModel
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> GetAll();
        Task<T> GetById(Guid id);
        Task<T> GetByName(string name);
    }
}
