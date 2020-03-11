using System;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.ViewModels;

namespace Kawaii.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IFollowService followService;
        private readonly IUserFollowRepository userSubscriptionRepository;

        public UserService(IUserRepository userRepository, IFollowService subscriptionsService,IUserFollowRepository userSubscriptionRepository)
        {
            this.userRepository = userRepository;
            this.followService = subscriptionsService;
            this.userSubscriptionRepository = userSubscriptionRepository;
        }

        public async Task<UserInfoViewModel> GetAsync(Guid id) =>
            await userRepository
                .GetQuery()
                .Select(x => new UserInfoViewModel { UserId = x.Id, Name = x.Name })
                .FirstOrDefaultAsync(x => x.UserId == id);

        public UserInfoViewModel GetUserInfo(Guid userId, Guid currentUserId)
        {
            var user =  userRepository.GetQuery().FirstOrDefault(x => x.Id == userId);

            var userInfo = new UserInfoViewModel {UserId = user.Id, Name = user.Name};

            var isBeingFollowedByCurrentUser = followService.IsBeingFollowedBy(userId, currentUserId) || userId == currentUserId;
            var userFollowers= userSubscriptionRepository.GetQuery().Count(x => x.UserId == user.Id);
            var userFollowings = userSubscriptionRepository.GetQuery().Count(x => x.FollowerId == user.Id);

            userInfo.IsBeingFollowedByCurrentUser = isBeingFollowedByCurrentUser;
            userInfo.FollowersCount = userFollowers;
            userInfo.FollowingsCount = userFollowings;

            return userInfo;
        }

        public User CreateUser(RegisterViewModel model)
        {
            var user = new User { Name = model.Name, Email = model.Email, UserName = model.Email, Year = model.Year };

            return user;
        }

        private UserInfoViewModel Map(User source)
        {
            var destination = new UserInfoViewModel
            {
                Name = source.Name,
            };

            return destination;
        }
    }
}
