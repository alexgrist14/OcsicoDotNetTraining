using System;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class RolesRepository : MemoryBaseRepository<Role>, IRolesRepository
    {
        public override async Task RemoveAsync(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity doesn't exist.");
            }

            await base.RemoveAsync(entity);
        }

        public override async Task UpdateAsync(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity doesn't exist.");
            }

            await base.UpdateAsync(entity);
        }
    }
}
