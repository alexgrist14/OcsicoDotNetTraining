using System;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class RolesRepository : MemoryBaseRepository<Role>, IRolesRepository
    {
        public override void Remove(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity doesn't exist.");
            }

             base.Remove(entity);
        }

        public override void Update(Role entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity doesn't exist.");
            }

            base.Update(entity);
        }
    }
}
