using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetQuery();
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        List<T> GetAll();
    }
}
