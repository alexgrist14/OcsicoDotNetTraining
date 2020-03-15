using System;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.Domain.Contracts;

namespace Kawaii.DataAccess.Repositories.Contracts
{
    public interface IAppEntityRepository<T> where T : IEntityModel<Guid>
    {
        IQueryable<T> GetQuery();

        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(Guid id);
    }
}
