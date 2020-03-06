//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Network.Context
//{
//    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//    {
//        public AppDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            optionsBuilder.UseSqlServer("Server=DESKTOP-H65FSEA\\MSSQLSERVER05;Database=OrganizationManagment;Trusted_Connection=True;");

//            return new AppDbContext(optionsBuilder.Options);
//        }
//    }
//}
