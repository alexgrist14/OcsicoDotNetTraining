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
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserSubscriptionRepository userSubscriptionRepository;
        private readonly IDataContext dataContext;
        private readonly UserManager<User> userManager;

        public SubscriptionsService(
            IUserRepository userRepository,
            IUserSubscriptionRepository userSubscriptionRepository,
            UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.userSubscriptionRepository = userSubscriptionRepository;
            this.userManager = userManager;
        }

        public async Task Follow(Guid userToFollowId, Guid currentUserId)
        {
            var userSubscription = new UserSubscription()
            {
                UserId = userToFollowId,
                FollowerId = currentUserId,
            };

            if (IsBeingFollowedBy(userToFollowId, currentUserId))
            {
                return;
            }

            await userSubscriptionRepository.AddAsync(userSubscription);
            dataContext.SaveChangesAsync().GetAwaiter().GetResult();
        }


        public async Task Unfollow(Guid userToUnfollowId, Guid currentUserId)
        {
            if (!IsBeingFollowedBy(userToUnfollowId, currentUserId))
            {
                return;
            }

            var userFollower = userSubscriptionRepository
                .GetQuery()
                .FirstOrDefault(x => x.UserId == userToUnfollowId && x.FollowerId == currentUserId);

            if (userFollower == null)
            {
                return;
            }

            userSubscriptionRepository.Remove(userFollower);
            dataContext.SaveChangesAsync().GetAwaiter().GetResult();
        }

        public ICollection<UserViewModel> GetFollowers(ClaimsPrincipal user)
        {
            var userId = new Guid(userManager.GetUserId(user));
            var followers = userSubscriptionRepository
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
            var followings = userSubscriptionRepository
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

            var currentUserFollowings = userSubscriptionRepository.GetQuery().Where(x => x.FollowerId == currentUser.Id).ToList();

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

            return userSubscriptionRepository.GetQuery().FirstOrDefault(x => x.UserId == firstUser && x.FollowerId == secondUser) != null;
        }
    }
}
