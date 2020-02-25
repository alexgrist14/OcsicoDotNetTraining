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

        public async Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId)
        {
            var emgOrgRoles = employeeOrganizationRoleRepository.GetAll()
                 .FindAll(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId);

            foreach (var item in emgOrgRoles)
            {
                await employeeOrganizationRoleRepository.RemoveAsync(item);
            }
        }

        public List<Employee> GetAllEmployees(Guid organizationId)
        {
            var emgOrgRoles = employeeOrganizationRoleRepository.GetAll().FindAll(e => e.OrganizationId == organizationId);
            var employees = employeeRepository.GetAll()
                .FindAll(emp => emgOrgRoles.Select(e => e.EmployeeId).Contains(emp.Id));
            return employees;
        }

        public async Task<Organization> CreateAsync(string name)
        {
            var organization = new Organization { Name = name};
            var organizations = organizationRepository.GetAll();

            if (organizations.Any(org => org.Id == organization.Id))
            {
                throw new ArgumentException("Organization with same Id already exist");
            }

            await organizationRepository.AddAsync(organization);
       
            return organization;
        }

        public async Task AddEmployeeAsync(Guid organizationId, Guid employeeId, Guid roleId)
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
                var empOrgRoleRemove = CreateEmployeeOrganizationRole(organizationId, employeeId, (Guid)roleIdRemove);

                await employeeOrganizationRoleRepository.RemoveAsync(empOrgRoleRemove);
            }

            var empOrgRoleAdd = CreateEmployeeOrganizationRole(organizationId, employeeId, roleIdAdd);

            await employeeOrganizationRoleRepository.AddAsync(empOrgRoleAdd);
        }

        private EmployeeOrganizationRole CreateEmployeeOrganizationRole(Guid organizationId, Guid employeeId, Guid roleId) => new EmployeeOrganizationRole
        {
            EmployeeId = employeeId,
            OrganizationId = organizationId,
            RoleId = roleId
        };
    }
}
