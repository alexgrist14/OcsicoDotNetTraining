using EntityModels.Context;
using Kawaii.DataAccess.Context;
using Kawaii.DataAccess.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SocialNetwork.Configurations
{
    public static class DataContextConfiguration
    {
        public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataContext, DataContext>();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"])
                    .UseLazyLoadingProxies());
        }
    }
}
