using System;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class EmployeeOrganizationRole : IAppEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid RoleId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Role Role { get; set; }
    }
}
