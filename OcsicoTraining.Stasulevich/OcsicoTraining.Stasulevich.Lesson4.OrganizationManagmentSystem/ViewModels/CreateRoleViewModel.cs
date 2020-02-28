using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
