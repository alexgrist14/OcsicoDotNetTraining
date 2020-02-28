using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagment.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
