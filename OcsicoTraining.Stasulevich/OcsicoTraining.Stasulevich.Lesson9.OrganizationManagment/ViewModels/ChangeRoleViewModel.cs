using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OcsicoTraining.Stasulevich.Lesson9.OrganizationManagment.ViewModels
{
    public class ChangeRoleViewModel
    {
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public List<IdentityRole> AllRoles { get; set; }

        public IList<string> UserRoles { get; set; }
    }
}
