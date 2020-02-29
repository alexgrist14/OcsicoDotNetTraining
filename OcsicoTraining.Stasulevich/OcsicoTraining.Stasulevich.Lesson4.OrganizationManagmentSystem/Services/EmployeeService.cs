using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagment.ViewModels;
using System.Linq;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services
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

        public async Task<EmployeeViewModel> CreateAsync(EmployeeViewModel employeeModel)
        {
            var employee = new Employee { Name = employeeModel.Name };

            await employeeRepository.AddAsync(employee);
            await dataContext.SaveChangesAsync();

            return new EmployeeViewModel { Id = employee.Id, Name = employeeModel.Name };
        }

        public async Task<List<Employee>> GetAsync() => await employeeRepository.GetQuery().ToListAsync();

        //public async Task<Employee> GetAsync(Guid id) =>
        //    await employeeRepository.GetQuery().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<EmployeeViewModel> GetAsync(Guid id) =>
            await employeeRepository
                    .GetQuery()
                    .Select(e => new EmployeeViewModel { Id = e.Id, Name = e.Name })
                    .FirstOrDefaultAsync(e => e.Id == id);


        public async Task RemoveAsync(Employee employee)
        {
            employeeRepository.Remove(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(EmployeeViewModel employeeModel)
        {
            var employee = new Employee { Id = employeeModel.Id, Name = employeeModel.Name };

            employeeRepository.Remove(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            employeeRepository.Update(employee);
            await dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeViewModel employeeModel)
        {
            var employee = new Employee { Id = employeeModel.Id, Name = employeeModel.Name };

            employeeRepository.Update(employee);
            await dataContext.SaveChangesAsync();
        }
    }
}
