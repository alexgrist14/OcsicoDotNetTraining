using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.ViewModels
{
    public class CreateOrganizationViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
