using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;

        public OrganizationService(IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository)
        {
            this.organizationRepository = organizationRepository;
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
        }

        public async Task RemoveEmployeeFromOrganizationAsync(Guid organizationId, Guid employeeId)
        {
            var emgOrgRoles = employeeOrganizationRoleRepository.GetAll()
                 .FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var item in emgOrgRoles)
            {
                employeeOrganizationRoleRepository.Remove(item);
            }
        }

        public List<Employee> GetAllEmployees(Guid organizationId)
        {
            var emgOrgRoles = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.OrganizationId == organizationId);
            var employees = employeeRepository.GetAll()
                .FindAll(emp => emgOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));
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

            organizationRepository.AddAsync(organization);

            return organization;
        }

        public async Task AddEmployeeOrganizationAsync(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var empOrgRole = new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };

            await employeeOrganizationRoleRepository.AddAsync(empOrgRole);
        }

        public async Task AssignEmployeeToNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleIdAdd, Guid? roleIdRemove)
        {
            if (roleIdRemove != null)
            {
                var empOrgRoleRemove = CreateStagingEntity(organizationId, employeeId, (Guid)roleIdRemove);

                employeeOrganizationRoleRepository.Remove(empOrgRoleRemove);
            }

            var empOrgRoleAdd = CreateStagingEntity(organizationId, employeeId, roleIdAdd);

            await employeeOrganizationRoleRepository.AddAsync(empOrgRoleAdd);
        }

        private EmployeeOrganizationRole CreateStagingEntity(Guid organizationId, Guid employeeId, Guid roleId) => new EmployeeOrganizationRole
        {
            EmployeeId = employeeId,
            OrganizationId = organizationId,
            RoleId = roleId
        };
    }
}
