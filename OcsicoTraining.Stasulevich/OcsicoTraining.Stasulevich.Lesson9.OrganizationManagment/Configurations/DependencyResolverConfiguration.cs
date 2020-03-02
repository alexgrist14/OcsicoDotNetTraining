using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.Configurations
{
    public static class DependencyResolverConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeOrganizationRoleRepository, EmployeeOrganizationRoleRepository>();
            services.AddTransient<IOrganizationRepository, OrganizationRepository>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IRoleRepository, RolesRepository>();
            services.AddTransient<IRoleService, RolesService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
