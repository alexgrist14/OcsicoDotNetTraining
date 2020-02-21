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

        public async Task CreateEmployeeAsync(Employee employee) => await employeeRepository.AddAsync(employee);

        public List<Employee> GetAllEmployees() => employeeRepository.GetAll();

        public async Task RemoveEmployeeAsync(Guid id)
        {
            var employee = GetAllEmployees().FirstOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("Employee with that id doesn't exist");
            }

            employeeRepository.Remove(employee);

            var stagEntity = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.EmployeeId == id);

            foreach (var item in stagEntity)
            {
                employeeOrganizationRoleRepository.Remove(item);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee) => employeeRepository.Update(employee);
    }
}
