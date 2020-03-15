using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kawaii.DataAccess.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-H65FSEA\\SQLEXPRESS;Database=Kawaii.SocialNetwork;Trusted_Connection=True;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
