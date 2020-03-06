using System;
using System.Reflection;
using Kawaii.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kawaii.DataAccess.Context
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureUser(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ConfigureUser(ModelBuilder builder)
        {
            //builder.Entity<User>().HasKey(x => x.Id);
            //builder.Entity<User>().Property(x => x.Id)
            //    .IsRequired()
            //    .ValueGeneratedOnAdd();

            builder.Entity<User>().Property(x => x.Name)
                .IsRequired();

            builder.Entity<User>().Property(x => x.Year)
                .IsRequired();



            //builder.Entity<UserLogin>().HasKey(x => x.Id);
            //builder.Entity<UserLogin>().Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Entity<UserRole>().HasKey(x => x.Id);
            builder.Entity<UserRole>().Property(x => x.Id).ValueGeneratedOnAdd();

            //builder.Entity<UserToken>().HasKey(x => x.Id);
            //builder.Entity<UserToken>().Property(x => x.Id).ValueGeneratedOnAdd();

            //builder.Entity<UserClaim>().HasKey(x => x.Id);
            //builder.Entity<UserClaim>().Property(x => x.Id).ValueGeneratedOnAdd();

            //builder.Entity<RoleClaim>().HasKey(x => x.Id);
            //builder.Entity<RoleClaim>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<UserClaim>().ToTable("UserClaims");
            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserLogin>().ToTable("UserLogins");
            builder.Entity<RoleClaim>().ToTable("RoleClaims");
            builder.Entity<UserToken>().ToTable("UserTokens");
            //builder.Entity<IdentityUserRole<Guid>>().ToTable("IdentityUserRole");
        }
    }
}
