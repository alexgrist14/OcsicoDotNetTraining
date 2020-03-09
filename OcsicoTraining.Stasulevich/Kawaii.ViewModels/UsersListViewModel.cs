using System;
using System.Collections.Generic;
using System.Text;

namespace Kawaii.ViewModels
{
    public class UsersListViewModel
    {
        public int UsersCount { get; set; } = 0;

        public string NoUsersWord;

        public IEnumerable<UserViewModel> Users { get; set; } = new HashSet<UserViewModel>();
    }
}
