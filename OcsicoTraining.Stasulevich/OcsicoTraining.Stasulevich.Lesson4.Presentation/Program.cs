using System;
using System.Threading.Tasks;
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
        public static async Task Main()
        {
            var serviceProvider = GetServiceProvider();
            var organizationServise = serviceProvider.GetService<IOrganizationService>();
            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var rolesService = serviceProvider.GetService<IRoleService>();

            var adminRole = rolesService.CreateRole("Admin");
            var juniorRole = rolesService.CreateRole("Junior");

            var orgBlizzard = await organizationServise.CreateOrganizationAsync("Blizzard");
            var orgNintendo = await organizationServise.CreateOrganizationAsync("Nintendo");
            var orgKyotoAnimation = await organizationServise.CreateOrganizationAsync("KyotoAnimation");

            var firstEmployee = await employeeService.CreateEmployee("Kojima");
            var secondEmployee = await employeeService.CreateEmployee("Kazuma");
            var thirdEmployee = await employeeService.CreateEmployee("Subaru");

            await organizationServise.AddEmployeeOrganizationAsync(orgBlizzard.Id, firstEmployee.Id, adminRole.Id);
            await organizationServise.AddEmployeeOrganizationAsync(orgNintendo.Id, secondEmployee.Id, juniorRole.Id);
            await organizationServise.AddEmployeeOrganizationAsync(orgKyotoAnimation.Id, thirdEmployee.Id, adminRole.Id);

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
