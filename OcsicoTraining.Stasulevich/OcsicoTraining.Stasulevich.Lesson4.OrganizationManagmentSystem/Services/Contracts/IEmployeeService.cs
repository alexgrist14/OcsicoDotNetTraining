using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(string name);

        Task RemoveAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task<List<Employee>> GetAsync();
    }
}
