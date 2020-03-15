using System.Collections.Generic;

namespace Kawaii.ViewModels
{
    public class PostsFeedAndUserInfoViewModel
    {
        public UserInfoViewModel CurrentUserInfo { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }

        public UserInfoViewModel UserProfileInfo { get; set; }
    }
}
