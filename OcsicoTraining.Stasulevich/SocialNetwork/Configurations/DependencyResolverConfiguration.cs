using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.DataAccess.Repositories;
using Kawaii.DataAccess.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.Configurations
{
    public static class DependencyResolverConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserFollowRepository, UserFollowRepository>();
            services.AddTransient<IFollowService, FollowService>();
            services.AddTransient<ISearchService, SearchService>();
        }
    }
}
