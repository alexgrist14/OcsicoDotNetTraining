using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);
        Task RemoveEmployeeAsync(Guid id);
        Task UpdateEmployeeAsync(Employee employee);
        List<Employee> GetAllEmployees();
    }
}
