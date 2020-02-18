using System;
using System.Collections.Generic;
using System.Linq;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Interface;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class OrganizationService: IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IStagingEntityRepository stagingEntityRepository;

        public OrganizationService(IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository, IStagingEntityRepository stagingEntityRepository)
        {
            this.organizationRepository = organizationRepository;
            this.employeeRepository = employeeRepository;
            this.stagingEntityRepository = stagingEntityRepository;
        }

        public void RemoveEmployeeFromOrganization(Guid organizationId, Guid employeeId)
        {
            var stagEntities = stagingEntityRepository.GetAll()
                 .FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach(var item in stagEntities)
            {
                stagingEntityRepository.Remove(item);
            }
        }

        public List<Employee> GetAllEmployees(Guid organizationId)
        {
            var stagEntities = stagingEntityRepository.GetAll().FindAll(e => e.OrganizationId == organizationId);
            var employees = employeeRepository.GetAll()
                .FindAll(emp => stagEntities.Select(e => e.EmployeeId).Contains(emp.Id));
            return employees;
        }

        public Organization CreateOrganization(string name)
        {
            var organization = new Organization { Name = name };
            var organizations = organizationRepository.GetAll();

            if (organizations.Any(org => org.Id == organization.Id))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            organizationRepository.Add(organization);

            return organization;
        }

        public void AddEmployeeOrganization(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var empOrgRole = new StagingEntity
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            stagingEntityRepository.Add(empOrgRole);
        }

        public void AssignEmployeeToNewRole(Guid organizationId, Guid employeeId, Guid roleIdAdd, Guid? roleIdRemove)
        {
            if(roleIdRemove != null)
            {
                var stagEntityRemove = CreateStagingEntity(organizationId, employeeId, (Guid)roleIdRemove);

                stagingEntityRepository.Remove(stagEntityRemove);
            }

            var stagEntityAdd = CreateStagingEntity(organizationId, employeeId, roleIdAdd);

            stagingEntityRepository.Add(stagEntityAdd);
        }

        private StagingEntity CreateStagingEntity(Guid organizationId, Guid employeeId, Guid roleId) => new StagingEntity
        {
            EmployeeId = employeeId,
            OrganizationId = organizationId,
            RoleId = roleId
        };
    }
}
