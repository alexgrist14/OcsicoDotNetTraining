using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeOrganizationRoleRepository : AppEntityRepository<EmployeeOrganizationRole>, IEmployeeOrganizationRoleRepository
    {
        public EmployeeOrganizationRoleRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
