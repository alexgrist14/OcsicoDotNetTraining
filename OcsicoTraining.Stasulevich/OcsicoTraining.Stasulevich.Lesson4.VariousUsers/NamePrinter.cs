using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.VariousUsers
{
    public class NamePrinter : IPrinter
    {
        public string Print(User user) => $"Name: {user.Name}";
    }
}
