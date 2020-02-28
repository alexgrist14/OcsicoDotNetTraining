using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts;


namespace OcsicoTraining.Stasulevich.Lesson4.Presentation
{
    public class Program
    {
        public static async Task Main()
        {
            var serviceProvider = DependencyInjection.GetServiceProvider();

            var organizationServise = serviceProvider.GetService<IOrganizationService>();
            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var rolesService = serviceProvider.GetService<IRoleService>();

            var adminRole = await rolesService.CreateAsync("Admin");
            var juniorRole = await rolesService.CreateAsync("Junior");

            var orgBlizzard = await organizationServise.CreateAsync("Blizzard");
            var orgNintendo = await organizationServise.CreateAsync("Nintendo");
            var orgKyotoAnimation = await organizationServise.CreateAsync("KyotoAnimation");

            var firstEmployee = await employeeService.CreateAsync("Kojima");
            var secondEmployee = await employeeService.CreateAsync("Kazuma");
            var thirdEmployee = await employeeService.CreateAsync("Subaru");

            await organizationServise.AddEmployeeAsync(orgBlizzard.Id, firstEmployee.Id, adminRole.Id);
            await organizationServise.AddEmployeeAsync(orgNintendo.Id, secondEmployee.Id, juniorRole.Id);
            await organizationServise.AddEmployeeAsync(orgKyotoAnimation.Id, thirdEmployee.Id, adminRole.Id);

            Console.WriteLine("All Employees:");

            var allEmployees = await employeeService.GetAsync();

            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"Employee: {employee.Id} {employee.Name}");

                foreach (var employeeRole in employee.EmployeeOrganizationRoles)
                {
                    Console.WriteLine($"Company: {employeeRole.Organization.Name}, Role: {employeeRole.Role.Name}");
                }

                Console.WriteLine(new string('-', 30));
            }
        }
    }
}
