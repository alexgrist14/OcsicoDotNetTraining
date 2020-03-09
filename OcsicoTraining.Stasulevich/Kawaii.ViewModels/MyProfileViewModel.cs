using System;
using System.Collections.Generic;
using System.Text;

namespace Kawaii.ViewModels
{
    public class MyProfileViewModel : PostsFeedAndUserInfoViewModel
    {
        public UserInfoViewModel CurrentUserInfo { get; set; }

        public UsersListViewModel WhoToFollow { get; set; }
    }
}
