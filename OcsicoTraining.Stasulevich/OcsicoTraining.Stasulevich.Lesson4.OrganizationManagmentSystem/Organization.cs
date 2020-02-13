using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Organization
    {
        public Organization() => Id = Guid.NewGuid();

        public Guid Id { get; }
        public string Name { get; set; }
    }
}
