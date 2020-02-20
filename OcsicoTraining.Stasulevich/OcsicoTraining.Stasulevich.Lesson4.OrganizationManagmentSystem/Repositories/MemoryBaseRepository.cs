using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public abstract class MemoryBaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly List<T> Entities;

        protected MemoryBaseRepository() => Entities = new List<T>();

        public async Task AddAsync(T entity) => await Task.Run(() => Entities.Add(entity));

        public List<T> GetAll() => Entities;

        public virtual async Task RemoveAsync(T entity) => await Task.Run(() => Entities.Remove(entity));

        public virtual async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Entities.Remove(entity));
            await Task.Run(() => Entities.Add(entity));
        }
    }
}
