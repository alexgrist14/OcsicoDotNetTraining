using System;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Organization CreateOrganization(string name);
        List<Employee> GetAllEmployees(Guid organizationId);
        void RemoveEmployeeFromOrganization(Guid organizationId, Guid employeeId);
        void AddEmployeeOrganization(Guid organizationId, Guid employeeId, Guid roleId);
        void AssignEmployeeToNewRole(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
    }
}
