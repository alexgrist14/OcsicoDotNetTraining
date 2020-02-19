using System;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Roles
    {
        public Roles() => Id = Guid.NewGuid();

        public Guid Id { get; }

        public string Name { get; set; }
    }
}
