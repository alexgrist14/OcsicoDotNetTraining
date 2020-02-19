using System;
using System.Linq;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class RolesRepository : MemoryBaseRepository<Roles>, IRolesRepository
    {
        public override void Remove(Roles entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity doesn't exist.");
            }

            base.Remove(entity);
        }

        public override void Update(Roles entity)
        {
            if (!Entities.Any(e => e.Id == entity.Id))
            {
                throw new ArgumentException("Entity doesn't exist.");
            }

            base.Update(entity);
        }
    }
}
