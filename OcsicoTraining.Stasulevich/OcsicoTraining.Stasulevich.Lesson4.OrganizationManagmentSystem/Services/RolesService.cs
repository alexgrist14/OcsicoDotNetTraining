using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services
{
    public class RolesService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IDataContext dataContext;

        public RolesService(IRoleRepository rolesRepository, IDataContext dataContext)
        {
            this.roleRepository = rolesRepository;
            this.dataContext = dataContext;
        }

        public async Task<Role> CreateAsync(string name)
        {
            var role = new Role { Name = name };

            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();

            return role;
        }

        public async Task<RoleViewModel> CreateAsync(RoleViewModel roleModel)
        {
            var role = new Role { Name = roleModel.Name };

            await roleRepository.AddAsync(role);
            await dataContext.SaveChangesAsync();

            return new RoleViewModel { Name = role.Name };
        }

        public async Task<List<Role>> GetAsync() => await roleRepository.GetQuery().ToListAsync();

        public async Task<Role> GetAsync(Guid id) =>
            await roleRepository.GetQuery().FirstOrDefaultAsync(r => r.Id == id);

        public async Task<RoleViewModel> GetViewModelAsync(Guid id) =>
            await roleRepository.GetQuery()
                .Select(r => new RoleViewModel { Id = r.Id, Name = r.Name })
                .FirstOrDefaultAsync(r => r.Id == id);

        public async Task RemoveAsync(Role role)
        {
            roleRepository.Remove(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(RoleViewModel roleModel)
        {
            var role = new Role { Id = roleModel.Id, Name = roleModel.Name };

            roleRepository.Remove(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            roleRepository.Update(role);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoleViewModel roleModel)
        {
            var role = new Role { Id = roleModel.Id, Name = roleModel.Name };

            roleRepository.Update(role);
            await dataContext.SaveChangesAsync();
        }
    }
}
