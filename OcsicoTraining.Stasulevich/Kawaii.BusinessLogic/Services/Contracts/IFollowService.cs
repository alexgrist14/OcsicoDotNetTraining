using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kawaii.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface IFollowService
    {
        Task Follow(Guid usertoFollowId, Guid currentUserId);

        Task Unfollow(Guid userToUnfollowId, Guid currentUserId);

        IEnumerable<UserViewModel> GetUsersToFollow(ClaimsPrincipal user);

        ICollection<UserViewModel> GetFollowers(ClaimsPrincipal user);

        ICollection<UserViewModel> GetFollowings(ClaimsPrincipal user);

        bool IsBeingFollowedBy(Guid userToWollowId, Guid currentUserId);
    }
}
