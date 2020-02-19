using System.Collections.Generic;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services
{
    public class RolesService : IRoleService
    {
        private readonly IRolesRepository rolesRepository;

        public RolesService(IRolesRepository rolesRepository) => this.rolesRepository = rolesRepository;

        public void CreateRole(string name) => rolesRepository.Add(name);

        public List<Roles> GetAllRoles() => rolesRepository.GetAll();

        public void RemoveRole(Roles role) => rolesRepository.Remove(role);

        public void UpdateRole(Roles role) => rolesRepository.Update(role);
    }
}
