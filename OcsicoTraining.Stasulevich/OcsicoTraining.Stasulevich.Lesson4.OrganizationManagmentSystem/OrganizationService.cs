using System;
using System.Collections.Generic;
using System.Text;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Interface;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class OrganizationService
    {
        private readonly IRepository<Employee> _empRepository;

        public OrganizationService(IRepository<Employee> empRepository) => _empRepository = empRepository;

        public Employee RemoveEmployeeFromOrganization(string name)
        {
            var employee = new Employee()
            {
                Name = name,
            };

            _empRepository.Add(employee);
            return employee;
        }
        public List<Employee> GetAllEmployees() => _empRepository.GetAll();
    }
}
