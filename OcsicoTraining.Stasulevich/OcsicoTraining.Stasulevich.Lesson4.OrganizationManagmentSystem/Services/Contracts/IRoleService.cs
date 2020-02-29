using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Task<Role> CreateAsync(string name);

        Task<RoleViewModel> CreateAsync(RoleViewModel roleModel);

        Task RemoveAsync(Role role);

        Task RemoveAsync(RoleViewModel roleViewModel);

        Task UpdateAsync(Role role);

        Task UpdateAsync(RoleViewModel roleViewModel);

        Task<List<Role>> GetAsync();

        Task<Role> GetAsync(Guid id);

        Task<RoleViewModel> GetViewModelAsync(Guid id);
    }
}
