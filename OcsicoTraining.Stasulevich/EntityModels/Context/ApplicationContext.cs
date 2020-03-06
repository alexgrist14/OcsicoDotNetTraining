using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityModels
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Entity<User>().Property(x => x.Name)
                .IsRequired();

            builder.Entity<User>().Property(x => x.Year)
                .IsRequired();

            builder.Entity<User>().Property(x => x.Email)
                .IsRequired();

            builder.Entity<User>().Property(x => x.PasswordHash)
                .IsRequired();

            builder.Entity<User>().ToTable("Users");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
