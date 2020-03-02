using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email not specified")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password not specified")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password do not equals")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

    }
}
