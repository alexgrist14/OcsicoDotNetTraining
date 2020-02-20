using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        void CreateRole(Role role);
        void RemoveRole(Role role);
        void UpdateRole(Role role);
        List<Role> GetAllRoles();
    }
}
