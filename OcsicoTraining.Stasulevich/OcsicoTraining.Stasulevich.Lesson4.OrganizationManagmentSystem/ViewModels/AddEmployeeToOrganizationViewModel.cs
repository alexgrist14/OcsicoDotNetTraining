using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels
{
    public class AddEmployeeToOrganizationViewModel
    {
        public Guid OrganizationId { get; set; }

        [Required, DisplayName("Employee")]
        public Guid? SelectedEmployeeId { get; set; }

        [Required, DisplayName("Role")]
        public Guid? SelectedRoleId { get; set; }

        public List<SelectListItem> Employees { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}
