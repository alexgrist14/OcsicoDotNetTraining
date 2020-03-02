using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email not specified")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password not specified")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

    }
}
