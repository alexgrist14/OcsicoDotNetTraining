using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Role CreateRole(string name);
        void RemoveRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetAllRoles();
    }
}
