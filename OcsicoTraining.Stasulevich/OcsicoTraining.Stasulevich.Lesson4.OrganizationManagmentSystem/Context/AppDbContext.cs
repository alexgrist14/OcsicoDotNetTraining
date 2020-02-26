using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
