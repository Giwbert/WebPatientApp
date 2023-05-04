
using PatientDomain.Entities;
using WebPatientApp.Models.Domain;
using WebPatientApp.Models.DTO;
using WebPatientApp.Repositories.Abstract;

namespace WebPatientApp.Repositories.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly DatabaseContext ctx;
        public PatientService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Patient model)
        {
            try
            {
                
                ctx.Patients.Add(model);
                ctx.SaveChanges();
              
                return true;
            }
            catch (Exception ex)
            {
                return false;
            } 
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;

                ctx.Patients.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Patient GetById(int id)
        {
            return ctx.Patients.Find(id);
        }

        public PatientListVm List(string term="",bool paging=false, int currentPage=0)
        {
            var data = new PatientListVm();
           
            var list = ctx.Patients.ToList();
           
            if (paging)
            {
                // here we will apply paging
                int pageSize = 5;
                int count = list.Count;
                int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                list = list.Skip((currentPage - 1)*pageSize).Take(pageSize).ToList();
                data.PageSize = pageSize;
                data.CurrentPage = currentPage;
                data.TotalPages = TotalPages;
            }
            data.PatientList = list.AsQueryable();

            return data;
        }

        public bool Update(Patient model)
        {
            try
            {
                ctx.Patients.Update(model);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
    }
}
