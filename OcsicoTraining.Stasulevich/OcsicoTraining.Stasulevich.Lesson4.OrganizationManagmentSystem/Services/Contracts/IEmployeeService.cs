using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagment.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(string name);

        Task<EmployeeViewModel> CreateAsync(EmployeeViewModel employeeModel);

        Task RemoveAsync(Employee employee);

        Task RemoveAsync(EmployeeViewModel employeeModel);

        Task UpdateAsync(Employee employee);

        Task UpdateAsync(EmployeeViewModel employeeModel);

        Task<List<Employee>> GetAsync();

        Task<EmployeeViewModel> GetAsync(Guid id);
    }
}
