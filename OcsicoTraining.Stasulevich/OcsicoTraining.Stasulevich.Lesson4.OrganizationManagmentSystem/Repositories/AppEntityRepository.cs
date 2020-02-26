using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class AppEntityRepository<T> : IAppEntityRepository<T> where T : class, IAppEntity<Guid>
    {
        public AppEntityRepository(IDataContext dataContext)
        {
            EntitiesSet = dataContext.Set<T>();
        }

        protected DbSet<T> EntitiesSet { get; private set; }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.Attach(entity);
            await EntitiesSet.AddAsync(entity);
        }

        public IQueryable<T> GetQuery() => EntitiesSet;

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.Attach(entity);
            EntitiesSet.Remove(entity);
        }

        public void Remove(Guid id)
        {
            var entity = EntitiesSet.FirstOrDefault(x => x.Id == id);
            Remove(entity);
        }

        public void RemoveRange(List<T> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.AttachRange(entity);
            EntitiesSet.RemoveRange(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.Attach(entity);
            EntitiesSet.Update(entity);
        }
    }
}
