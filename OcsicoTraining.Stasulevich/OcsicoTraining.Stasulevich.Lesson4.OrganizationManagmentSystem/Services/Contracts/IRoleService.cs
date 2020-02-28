using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Task<Role> CreateAsync(string name);

        Task<CreateRoleViewModel> CreateAsync(CreateRoleViewModel roleModel);

        Task RemoveAsync(Role role);

        Task UpdateAsync(Role role);

        Task<List<Role>> GetAsync();

        Task<Role> GetAsync(Guid id);
    }
}
