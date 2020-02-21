using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Role CreateRole(string name);
        Task RemoveRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        List<Role> GetAllRoles();
    }
}
