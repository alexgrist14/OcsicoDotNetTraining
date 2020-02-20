using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Task CreateRoleAsync(Role role);
        Task RemoveRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        List<Role> GetAllRoles();
    }
}
