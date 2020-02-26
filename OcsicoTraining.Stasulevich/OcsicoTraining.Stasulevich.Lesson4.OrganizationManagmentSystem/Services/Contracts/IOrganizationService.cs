using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Task<Organization> CreateAsync(string name);

        Task AddEmployeeAsync(Guid organizationId, Guid employeeId, Guid roleId);

        Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId);

        Task AssignEmployeeToNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);

        Task<List<Employee>> GetEmployeesAsync(Guid organizationId);
    }
}
