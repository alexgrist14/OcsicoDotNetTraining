using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(string name);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Employee employee);
        List<Employee> GetAll();
    }
}
