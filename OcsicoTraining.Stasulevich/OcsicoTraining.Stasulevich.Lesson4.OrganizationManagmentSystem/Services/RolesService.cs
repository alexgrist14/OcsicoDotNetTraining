using System.Collections.Generic;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services
{
    public class RolesService : IRoleService
    {
        private readonly IRolesRepository rolesRepository;

        public RolesService(IRolesRepository rolesRepository) => this.rolesRepository = rolesRepository;

        public void CreateRole(Role role) => rolesRepository.Add(role);

        public List<Role> GetAllRoles() => rolesRepository.GetAll();

        public void RemoveRole(Role role) => rolesRepository.Remove(role);

        public void UpdateRole(Role role) => rolesRepository.Update(role);
    }
}
