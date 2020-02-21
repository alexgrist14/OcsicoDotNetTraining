using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services
{
    public class RolesService : IRoleService
    {
        private readonly IRolesRepository rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public Role CreateRole(string name)
        {
            var role = new Role { Name = name};
            var roles = rolesRepository.GetAll();

            if(roles.Any(rol => rol.Id == role.Id))
            {
                throw new ArgumentException("Role with same Id already exist");
            }

            rolesRepository.AddAsync(role);

            return role;
        }

        public List<Role> GetAllRoles() => rolesRepository.GetAll();

        public async Task RemoveRoleAsync(Role role) => rolesRepository.Remove(role);

        public async Task UpdateRoleAsync(Role role) => rolesRepository.Update(role);
    }
}
