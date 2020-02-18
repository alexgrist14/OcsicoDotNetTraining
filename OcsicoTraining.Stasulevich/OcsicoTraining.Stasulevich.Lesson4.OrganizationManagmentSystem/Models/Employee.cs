using System;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Employee
    {
        public Employee() => Id = Guid.NewGuid();
        public Guid Id { get; }

        public string Name { get; set; }
    }
}
