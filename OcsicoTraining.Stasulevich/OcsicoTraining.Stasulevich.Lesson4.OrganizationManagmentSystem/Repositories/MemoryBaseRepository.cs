using System.Collections.Generic;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public abstract class MemoryBaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly List<T> Entities;
        protected MemoryBaseRepository() => Entities = new List<T>();

        public void Add(T entity) => Entities.Add(entity);

        public List<T> GetAll() => Entities;

        public virtual void Remove(T entity) => Entities.Remove(entity);

        public virtual void Update(T entity)
        {
            _ = Entities.Remove(entity);
            Entities.Add(entity);
        }
    }
}
