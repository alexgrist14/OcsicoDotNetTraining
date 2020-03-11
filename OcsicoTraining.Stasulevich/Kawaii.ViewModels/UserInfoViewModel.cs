using System;
using System.Collections.Generic;
using System.Text;

namespace Kawaii.ViewModels
{
    public class UserInfoViewModel
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int FollowersCount { get; set; }

        public int FollowingsCount { get; set; }

        public bool IsBeingFollowedByCurrentUser { get; set; }

    }
}
