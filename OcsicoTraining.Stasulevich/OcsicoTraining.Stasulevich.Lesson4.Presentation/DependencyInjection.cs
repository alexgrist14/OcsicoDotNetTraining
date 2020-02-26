using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services;

namespace OcsicoTraining.Stasulevich.Lesson4.Presentation
{
    public class DependencyInjection
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-H65FSEA\\MSSQLSERVER05;Database=OrganizationManagment;Trusted_Connection=True;")
                    .UseLazyLoadingProxies()
                    .EnableSensitiveDataLogging());

            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterType<DataContext>().As<IDataContext>();

            containerBuilder.RegisterType<RolesRepository>().As<IRoleRepository>();
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
