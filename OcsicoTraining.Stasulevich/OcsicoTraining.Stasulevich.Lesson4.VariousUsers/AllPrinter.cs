using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.VariousUsers
{
    public class AllPrinter : IPrinter
    {
        public string Print(User user) => $"Name:{user.Name}, PhoneNumber: {user.PhoneNumber}, Salary: {user.Salary}";
    }
}
