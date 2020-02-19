using System;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Role
    {
        public Role() => Id = Guid.NewGuid();

        public Guid Id { get; }

        public string Name { get; set; }
    }
}
