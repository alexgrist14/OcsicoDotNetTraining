using System;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Employee : IAppEntity<Guid>
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
