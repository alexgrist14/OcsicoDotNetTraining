using System;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories;
using OcsicoTraining.Stasulevich.Lesson4.VariousUsers;

namespace OcsicoTraining.Stasulevich.Lesson4.Presentation
{
    public class Program
    {
        //IEmployeeService, EmployeeService

        public static void Main()
        {
            var user = new User { Name = "Billy", PhoneNumber = "3425434", Salary = 300 };

            var emp = new EmployeeService(new EmployeeRepository());
           Console.WriteLine( emp.CreateEmployee("Vasya"));
            Console.WriteLine(emp.GetAllEmployees());


            Console.Write(Guid.NewGuid());

            //Console.WriteLine(user.PrintInfo(new AllPrinter()));
            //Console.WriteLine(user.PrintInfo(new NameAndSalaryPrinter()));
            //Console.WriteLine(user.PrintInfo(new SalaryPrinter()));
            //Console.WriteLine(user.PrintInfo(new NamePrinter()));
        }
    }
}
