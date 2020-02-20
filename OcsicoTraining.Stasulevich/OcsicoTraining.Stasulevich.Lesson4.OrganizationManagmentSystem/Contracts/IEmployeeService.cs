using System;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        void RemoveEmployee(Guid id);
        void UpdateEmployee(Employee employee);
        List<Employee> GetAllEmployees();
    }
}
