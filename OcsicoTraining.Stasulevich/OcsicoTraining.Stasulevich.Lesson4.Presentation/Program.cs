using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services;


namespace OcsicoTraining.Stasulevich.Lesson4.Presentation
{
    public class Program
    {
        public static void Main()
        {
            var serviceProvider = GetServiceProvider();
            var organizationServise = serviceProvider.GetService<IOrganizationService>();
            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var rolesService = serviceProvider.GetService<IRoleService>();

            var adminRole = new Role { Name = "Admin" };
            var juniorRole = new Role { Name = "Junior" };

            var orgBlizzard = organizationServise.CreateOrganization("Blizzard");
            var orgNintendo = organizationServise.CreateOrganization("Nintendo");
            var orgKyotoAnimation = organizationServise.CreateOrganization("KyotoAnimation");

            var firstEmployee = new Employee { Name = "Kojima" };
            var secondEmployee = new Employee { Name = "Kazuma" };
            var thirdEmployee = new Employee { Name = "Subaru" };

            rolesService.CreateRole(adminRole);
            rolesService.CreateRole(juniorRole);
            employeeService.CreateEmployee(firstEmployee);
            employeeService.CreateEmployee(secondEmployee);
            employeeService.CreateEmployee(thirdEmployee);
            organizationServise.AddEmployeeOrganization(orgBlizzard.Id, firstEmployee.Id, adminRole.Id);
            organizationServise.AddEmployeeOrganization(orgNintendo.Id, secondEmployee.Id, juniorRole.Id);
            organizationServise.AddEmployeeOrganization(orgKyotoAnimation.Id, thirdEmployee.Id, adminRole.Id);

            var employees = organizationServise.GetAllEmployees(orgBlizzard.Id);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id} {employee.Name}");
            }
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterType<RolesRepository>().As<IRolesRepository>();
            containerBuilder.RegisterType<EmployeeOrganizationRoleRepository>().As<IEmployeeOrganizationRoleRepository>();
            containerBuilder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            containerBuilder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>();
            containerBuilder.RegisterType<RolesService>().As<IRoleService>();
            containerBuilder.RegisterType<OrganizationService>().As<IOrganizationService>();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>();

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
