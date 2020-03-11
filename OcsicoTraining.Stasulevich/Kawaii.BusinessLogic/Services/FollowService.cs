using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.DataAccess.Context.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kawaii.BusinessLogic.Services
{
    public class FollowService : IFollowService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserFollowRepository userFollowRepository;
        private readonly IDataContext dataContext;
        private readonly UserManager<User> userManager;

        public FollowService(
            IUserRepository userRepository,
            IUserFollowRepository userSubscriptionRepository,
            IDataContext dataContext,
            UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userFollowRepository = userSubscriptionRepository;
            this.userManager = userManager;
            this.dataContext = dataContext;
        }

        public async Task Follow(Guid userToFollowId, Guid currentUserId)
        {
            var userSubscription = new UserFollow()
            {
                UserId = userToFollowId,
                FollowerId = currentUserId,
            };

            if (IsBeingFollowedBy(userToFollowId, currentUserId))
            {
                return;
            }

            await userFollowRepository.AddAsync(userSubscription);
            await dataContext.SaveChangesAsync();
        }


        public async Task Unfollow(Guid userToUnfollowId, Guid currentUserId)
        {
            if (!IsBeingFollowedBy(userToUnfollowId, currentUserId))
            {
                return;
            }

            var userFollower = userFollowRepository
                .GetQuery()
                .FirstOrDefault(x => x.UserId == userToUnfollowId && x.FollowerId == currentUserId);

            if (userFollower == null)
            {
                return;
            }

            userFollowRepository.Remove(userFollower);
            await dataContext.SaveChangesAsync();
        }

        public ICollection<UserViewModel> GetFollowers(ClaimsPrincipal user)
        {
            var userId = new Guid(userManager.GetUserId(user));
            var followers = userFollowRepository
                .GetQuery()
                .Include(x => x.Follower)
                .Where(x => x.UserId == userId && x.FollowerId != userId)
                .Select(x => x.Follower)
                .ToList();

            var followersViewModels = followers.Select(x => new UserViewModel { Id = x.Id, UserName = x.Name }).ToList();

            foreach (var follower in followersViewModels)
            {
                follower.IsFollowingCurrentUser = IsBeingFollowedBy(follower.Id, userId);
            }

            return followersViewModels;
        }

        public ICollection<UserViewModel> GetFollowings(ClaimsPrincipal user)
        {
            var userId = new Guid(userManager.GetUserId(user));
            var followings = userFollowRepository
                .GetQuery()
                .Include(x => x.User).Where(x => x.FollowerId == userId && x.UserId != userId)
                .Select(x => x.User)
                .ToList();

            var followingsViewsModels = followings.Select(x => new UserViewModel { Id = x.Id, UserName = x.Name }).ToList();

            foreach (var following in followingsViewsModels)
            {
                following.IsFollowingCurrentUser = IsBeingFollowedBy(following.Id, userId);
            }

            return followingsViewsModels;

        }

        public IEnumerable<UserViewModel> GetUsersToFollow(ClaimsPrincipal user)
        {
            var currentUser = userManager.GetUserAsync(user).GetAwaiter().GetResult();
            var allUsers = userRepository.GetQuery().Where(x => x.Id != currentUser.Id);
            var usersViewsModels = allUsers.Select(x => new UserViewModel { Id = x.Id, UserName = x.Name }).Take(10).ToList();

            if (usersViewsModels.Count == 0)
            {
                return null;
            }

            var currentUserFollowings = userFollowRepository.GetQuery().Where(x => x.FollowerId == currentUser.Id).ToList();

            foreach (var followingUserId in currentUserFollowings)
            {
                var followingUser = userRepository.GetQuery().FirstOrDefault(x => x.Id == followingUserId.UserId);

                if (followingUser == null)
                {
                    continue;
                }
                if (usersViewsModels.FirstOrDefault(x => x.Id == followingUser.Id) != null)
                {
                    usersViewsModels.RemoveAll(x => x.Id == followingUser.Id);
                    continue;
                }
            }

            return usersViewsModels;
        }

        public bool IsBeingFollowedBy(Guid userToWollowId, Guid currentUserId)
        {
            var firstUser = userToWollowId;
            var secondUser = currentUserId;

            return userFollowRepository.GetQuery().FirstOrDefault(x => x.UserId == firstUser && x.FollowerId == secondUser) != null;
        }
    }
}
