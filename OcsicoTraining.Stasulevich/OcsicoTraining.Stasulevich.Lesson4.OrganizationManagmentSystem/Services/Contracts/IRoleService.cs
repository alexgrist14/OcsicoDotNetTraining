using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts
{
    public interface IRoleService
    {
        Task<Role> CreateAsync(string name);

        Task RemoveAsync(Role role);

        Task UpdateAsync(Role role);

        Task<List<Role>> GetAsync();
    }
}
