using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Contracts;

namespace Repositories.Contracts
{
    public interface IEntityRepository<T> where T : IEntityModel<Guid>
    {
        IQueryable<T> GetQuery();

        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(Guid id);

        void RemoveRange(List<T> entity);
    }
}
