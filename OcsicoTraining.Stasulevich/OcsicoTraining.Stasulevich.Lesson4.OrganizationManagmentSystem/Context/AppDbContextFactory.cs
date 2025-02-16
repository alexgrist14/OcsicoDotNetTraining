using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-H65FSEA\\MSSQLSERVER05;Database=OrganizationManagment;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
