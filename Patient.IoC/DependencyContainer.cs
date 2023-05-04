using Microsoft.Extensions.DependencyInjection;
using PatientApplication.Interface;
using PatientApplication.Services;
using PatientApplication.ViewModels;
using PatientData.Repositories;
using PatientDomain.Interfaces;
using System;

namespace Patient.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IService<PatientViewModel>), typeof(PatientService));
            services.AddScoped(typeof(IGenericRepository<PatientDomain.Entities.Patient>), typeof(PatientRepository));
        }
    }
}