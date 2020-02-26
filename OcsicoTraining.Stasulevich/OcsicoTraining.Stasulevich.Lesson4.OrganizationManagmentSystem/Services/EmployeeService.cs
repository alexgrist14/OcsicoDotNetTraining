using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;
        private readonly IDataContext dataContext;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository, IDataContext dataContext)
        {
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Employee> CreateAsync(string name)
        {
            var employee = new Employee { Name = name };

            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangesAsync();

            return employee;
        }

        public async Task<List<Employee>> GetAsync() => await employeeRepository.GetQuery().ToListAsync();

        public async Task RemoveAsync(Employee employee)
        {
            employeeRepository.Remove(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            employeeRepository.Update(employee);
            await dataContext.SaveChangesAsync();
        }
    }
}
