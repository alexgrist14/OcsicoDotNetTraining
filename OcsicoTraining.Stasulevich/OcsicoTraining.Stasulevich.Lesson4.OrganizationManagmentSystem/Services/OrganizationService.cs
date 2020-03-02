using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository;
        private readonly IDataContext dataContext;

        public OrganizationService(IOrganizationRepository organizationRepository, IEmployeeRepository employeeRepository, IEmployeeOrganizationRoleRepository employeeOrganizationRoleRepository, IDataContext dataContext)
        {
            this.organizationRepository = organizationRepository;
            this.employeeRepository = employeeRepository;
            this.employeeOrganizationRoleRepository = employeeOrganizationRoleRepository;
            this.dataContext = dataContext;
        }

        public async Task<Organization> CreateAsync(string name)
        {
            var organization = new Organization { Name = name };

            await organizationRepository.AddAsync(organization);
            await dataContext.SaveChangesAsync();

            return organization;
        }

        public async Task<CreateOrganizationViewModel> CreateAsync(CreateOrganizationViewModel organizationModel)
        {
            var organization = new Organization { Name = organizationModel.Name };

            await organizationRepository.AddAsync(organization);
            await dataContext.SaveChangesAsync();

            return new CreateOrganizationViewModel { Name = organizationModel.Name };
        }

        public async Task AddEmployeeAsync(Guid organizationId, Guid employeeId, Guid roleId)
        {
            var empOrgRole = CreateEmployeeOrganizationRole(organizationId, employeeId, roleId);

            await employeeOrganizationRoleRepository.AddAsync(empOrgRole);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveEmployeeAsync(Guid organizationId, Guid employeeId)
        {
            var emgOrgRoles = await employeeOrganizationRoleRepository
                .GetQuery()
                .Where(e => e.OrganizationId == organizationId && e.EmployeeId == employeeId)
                .ToListAsync();

            employeeOrganizationRoleRepository.RemoveRange(emgOrgRoles);
            await dataContext.SaveChangesAsync();
        }

        public async Task RemoveEmployeeAsync(RemoveEmployeeViewModel model)
        {
            var empOrgRoles = await employeeOrganizationRoleRepository
                .GetQuery()
                .Where(e => e.OrganizationId == model.OrganizationId && e.EmployeeId == model.EmployeeId)
                .ToListAsync();

            employeeOrganizationRoleRepository.RemoveRange(empOrgRoles);
            await dataContext.SaveChangesAsync();
        }

        public async Task AssignEmployeeToNewRoleAsync(Guid organizationId, Guid employeeId, Guid roleIdAdd, Guid? roleIdRemove)
        {
            if (roleIdRemove != null)
            {
                var empOrgRoleRemove = CreateEmployeeOrganizationRole(organizationId, employeeId, (Guid)roleIdRemove);

                employeeOrganizationRoleRepository.Remove(empOrgRoleRemove);
            }

            var empOrgRoleAdd = CreateEmployeeOrganizationRole(organizationId, employeeId, roleIdAdd);

            await employeeOrganizationRoleRepository.AddAsync(empOrgRoleAdd);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Organization>> GetAsync() =>
            await organizationRepository.GetQuery().ToListAsync();

        public async Task<List<OrganizationViewModel>> GetAllAsync()
        {
            var organizations = await GetAsync();

            return organizations.Select(x => new OrganizationViewModel { Id = x.Id, Name = x.Name }).ToList();
        }

        public async Task<Organization> GetAsync(Guid id) =>
            await organizationRepository.GetQuery().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<List<Employee>> GetEmployeesAsync(Guid organizationId)
        {
            var employees = await employeeRepository
                .GetQuery()
                .Where(emp => emp.EmployeeOrganizationRoles.Select(e => e.OrganizationId).Contains(organizationId))
                .ToListAsync();

            return employees.ToList();
        }

        public async Task<List<EmployeeOrganizationRole>> GetEmployeeRolesAsync(Guid organizationId) =>
            await employeeOrganizationRoleRepository
                .GetQuery()
                .Where(e => e.OrganizationId == organizationId)
                .ToListAsync();

        public async Task<List<EmployeeOrganizationRoleViewModel>> GetEmployeeRolesViewModelAsync(Guid organizationId)
        {
            var employeeRoles = await GetEmployeeRolesAsync(organizationId);

            return employeeRoles
                .Select(x =>
                    new EmployeeOrganizationRoleViewModel
                    {
                        Employee = x.Employee,
                        Organization = x.Organization,
                        Role = x.Role
                    })
                .ToList();
        }

        private EmployeeOrganizationRole CreateEmployeeOrganizationRole(Guid organizationId, Guid employeeId,
            Guid roleId) => new EmployeeOrganizationRole
            {
                EmployeeId = employeeId,
                OrganizationId = organizationId,
                RoleId = roleId
            };
    }
}
