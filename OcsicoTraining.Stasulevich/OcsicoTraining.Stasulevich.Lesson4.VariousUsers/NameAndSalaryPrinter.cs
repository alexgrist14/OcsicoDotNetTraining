using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.VariousUsers
{
    public class NameAndSalaryPrinter : IPrinter
    {
        public string Print(User user) => $"Name: {user.Name}, Salary: {user.Salary}";
    }
}
