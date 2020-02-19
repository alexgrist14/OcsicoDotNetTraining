using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.VariousUsers
{
    public class SalaryPrinter : IPrinter
    {
        public string Print(User user) => $"Salary: {user.Salary}";
    }
}
