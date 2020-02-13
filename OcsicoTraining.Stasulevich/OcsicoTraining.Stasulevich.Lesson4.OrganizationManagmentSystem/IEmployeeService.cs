using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public interface IEmployeeService
    {
        Employee CreateEmployee(Guid id, string name);
        Employee RemoveEmployee(Guid id);
        List<Employee> GetAllEmployees();
    }
}
