using System;
using OcsicoTraining.Stasulevich.Lesson4.VariousUsers;

namespace OcsicoTraining.Stasulevich.Lesson4.Presentation
{
    public class Program
    {
        public static void Main()
        {
            var user = new User { Name = "Billy", PhoneNumber = "3425434", Salary = 300 };

            Console.WriteLine(user.PrintInfo(new AllPrinter()));
            Console.WriteLine(user.PrintInfo(new NameAndSalaryPrinter()));
            Console.WriteLine(user.PrintInfo(new SalaryPrinter()));
            Console.WriteLine(user.PrintInfo(new NamePrinter()));
        }
    }
}
