using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories.Contracts
{
    public interface IAppEntityRepository<T> where T : IAppEntity<Guid>
    {
        IQueryable<T> GetQuery();

        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(Guid id);

        void RemoveRange(List<T> entity);
    }
}
