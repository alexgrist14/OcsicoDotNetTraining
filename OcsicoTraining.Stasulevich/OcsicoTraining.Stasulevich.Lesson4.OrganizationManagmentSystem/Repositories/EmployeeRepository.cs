using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeRepository : AppEntityRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
