using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Roles
    {
        public Roles() => Id = Guid.NewGuid();
        public Guid Id { get;}
        public string Name { get; set; }
    }
}
