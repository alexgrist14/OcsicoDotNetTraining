using System.Collections.Generic;
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

        public async Task CreateRoleAsync(Role role) => await rolesRepository.AddAsync(role);

        public List<Role> GetAllRoles() => rolesRepository.GetAll();

        public async Task RemoveRoleAsync(Role role) => rolesRepository.Remove(role);

        public async Task UpdateRoleAsync(Role role) => rolesRepository.Update(role);
    }
}
