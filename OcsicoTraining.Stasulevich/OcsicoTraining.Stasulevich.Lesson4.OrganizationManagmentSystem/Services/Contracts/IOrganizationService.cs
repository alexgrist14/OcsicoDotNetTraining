using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IOrganizationService
    {
        Task<Organization> CreateAsync(string name);

        Task<CreateOrganizationViewModel> CreateAsync(CreateOrganizationViewModel organizationModel);

        Task AddEmployeeAsync(Guid organizationId, Guid employeeId, Guid roleId);

        Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId);

        Task RemoveEmployeeAsync(RemoveEmployeeViewModel model);

        Task AssignEmployeeToNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleAdd, Guid? roleRemove);

        Task<List<Organization>> GetAsync();

        Task<Organization> GetAsync(Guid id);

        Task<List<EmployeeOrganizationRole>> GetEmployeeRolesAsync(Guid organizationId);

        Task<List<Employee>> GetEmployeesAsync(Guid organizationId);

        Task<List<EmployeeOrganizationRoleViewModel>> GetEmployeeRolesViewModelAsync(Guid organizationId);
    }
}
