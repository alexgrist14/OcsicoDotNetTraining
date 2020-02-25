using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
        }

        public async Task<Employee> CreateAsync(string name)
        {
            var employee = new Employee { Name = name };
            var employees = employeeRepository.GetAll();

            if (employees.Any(emp => emp.Id == employee.Id))
            {
                throw new ArgumentException("Employee with same Id already exist");
            }

            await employeeRepository.AddAsync(employee);

            return employee;
        }

        public List<Employee> GetAll() => employeeRepository.GetAll();

        public async Task RemoveAsync(Guid id)
        {
            var employee = GetAll().FirstOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("Employee with that id doesn't exist");
            }

            await employeeRepository.RemoveAsync(employee);

            var stagEntity = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.EmployeeId == id);

            foreach (var item in stagEntity)
            {
                await employeeOrganizationRoleRepository.RemoveAsync(item);
            }
        }

        public Task UpdateAsync(Employee employee) => employeeRepository.UpdateAsync(employee);
    }
}
