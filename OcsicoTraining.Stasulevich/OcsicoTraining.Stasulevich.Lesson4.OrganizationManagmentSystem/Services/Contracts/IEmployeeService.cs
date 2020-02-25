using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(string name);
        void RemoveEmployee(Guid id);
        void UpdateEmployee(Employee employee);
        List<Employee> GetAllEmployees();
    }
}
