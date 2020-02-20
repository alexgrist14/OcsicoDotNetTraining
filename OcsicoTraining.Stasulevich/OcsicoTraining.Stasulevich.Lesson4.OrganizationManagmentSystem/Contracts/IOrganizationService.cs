using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Organization CreateOrganization(string name);
        List<Employee> GetAllEmployees(Guid organizationId);
        Task RemoveEmployeeFromOrganizationAsync(Guid organizationId, Guid employeeId);
        Task AddEmployeeOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId);
        Task AssignEmployeeToNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);
    }
}
