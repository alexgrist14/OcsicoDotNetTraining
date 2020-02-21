using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        List<T> GetAll();
    }
}
