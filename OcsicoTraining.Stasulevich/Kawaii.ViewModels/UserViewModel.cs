using System;

namespace Kawaii.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public bool IsFollowingCurrentUser { get; set; }
    }
}
