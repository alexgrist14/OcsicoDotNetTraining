using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagment.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(string name);

        Task<CreateEmployeeViewModel> CreateAsync(CreateEmployeeViewModel employeeModel);

        Task RemoveAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task<List<Employee>> GetAsync();

        Task<Employee> GetAsync(Guid id);
    }
}
