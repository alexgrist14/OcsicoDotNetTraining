using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.VariousUsers
{
    public class User
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }

        public string PrintInfo(IPrinter printer) => printer.Print(this);
    }
}
