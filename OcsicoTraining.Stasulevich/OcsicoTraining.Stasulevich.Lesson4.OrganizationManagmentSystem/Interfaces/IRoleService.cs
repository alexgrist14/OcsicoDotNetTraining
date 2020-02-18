using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Interface
{
    public interface IRoleService
    {
        void CreateRole(Roles role);
        void RemoveRole(Roles role);
        void UpdateRole(Roles role);
        List<Roles> GetAllRoles();
    }
}
