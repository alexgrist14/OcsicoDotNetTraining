using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Organization CreateOrganizationAsync(string name);
        List<Employee> GetAllEmployees(Guid organizationId);
        void RemoveEmployeeFromOrganization(Guid organizationId, Guid employeeId);
        void AddEmployeeOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId);
        void AssignEmployeeToNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
    }
}
