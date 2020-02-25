using System;
using System.Collections;
using System.Collections.Generic;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class Employee : IAppEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public  virtual ICollection<EmployeeOrganizationRole> EmployeeOrganizationRoles { get; set; }
    }
}
