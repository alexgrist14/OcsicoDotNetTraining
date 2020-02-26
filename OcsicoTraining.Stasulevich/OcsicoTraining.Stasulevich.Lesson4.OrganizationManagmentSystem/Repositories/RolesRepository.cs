using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class RolesRepository : AppEntityRepository<Role>, IRoleRepository
    {
        public RolesRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
