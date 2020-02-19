using System;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem
{
    public class EmployeeOrganizationRole
    {
        public Guid EmployeeId { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid RoleId { get; set; }
    }
}
