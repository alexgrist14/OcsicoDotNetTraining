using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IStagingEntityRepository stagingEntityRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IStagingEntityRepository stagingEntity)
        {
            this.employeeRepository = employeeRepository;
            this.stagingEntityRepository = stagingEntity;
        }

        public void CreateEmployee(Employee employee) => employeeRepository.Add(employee);

        public List<Employee> GetAllEmployees() => employeeRepository.GetAll();

        public void RemoveEmployee(Guid id)
        {
            var employee = GetAllEmployees().FirstOrDefault(emp => emp.Id == id);

            if (employee == null)
            {
                throw new ArgumentException("Employee with that id doesn't exist");
            }

            employeeRepository.Remove(employee);

            var stagEntity = stagingEntityRepository.GetAll().FindAll(e => e.EmployeeId == id);

            foreach (var item in stagEntity)
            {
                stagingEntityRepository.Remove(item);
            }
        }

        public void UpdateEmployee(Employee employee) => employeeRepository.Update(employee);
    }
}
