using PatientApplication.Interface;
using PatientApplication.ViewModels;
using PatientDomain.Entities;
using PatientDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApplication.Services 
{
    public class PatientService : IService<PatientViewModel>
    {
        private readonly IGenericRepository<Patient> repo;
        private PatientViewModel patientVM;
        public PatientService(IGenericRepository<Patient> repo)
        {
            this.repo = repo;
        }

        public async Task<PatientViewModel> Add(PatientViewModel entity)
        {
            await repo.Add(entity.NewPatient);
            return entity;
        }

        public async Task<PatientViewModel> Update(PatientViewModel entity)
        {
            await repo.Update(entity.NewPatient);
            return entity;
        }

        public async Task<PatientViewModel> Delete(PatientViewModel entity)
        {
            await repo.Delete(entity.NewPatient.Id);
            return entity;
        }

        public async Task<PatientViewModel> GetAll()
        {
            patientVM = new PatientViewModel() { Patients = await repo.GetAll(), NewPatient = new() };
            return patientVM;
        }

        public Task<PatientViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PatientViewModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
