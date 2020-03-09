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
        //private readonly IUserSubscriptionRepository userSubscriptionRepository;

        public UserService(IUserRepository userRepository)//, IUserSubscriptionRepository userSubscriptionRepository)
        {
            this.userRepository = userRepository;
            //this.userSubscriptionRepository = userSubscriptionRepository;
        }

        public async Task<UserInfoViewModel> GetAsync(Guid id) =>
            await userRepository
                .GetQuery()
                .Select(x => new UserInfoViewModel { UserId = x.Id, Name = x.Name })
                .FirstOrDefaultAsync(x => x.UserId == id);

        public UserInfoViewModel GetUserInfo(Guid userId)
        {
            var user =  userRepository.GetQuery().FirstOrDefault(x => x.Id == userId);

            var userInfo = new UserInfoViewModel { Name = user.Name, FollowersCount = 0, FollowingsCount = 0 };

            return userInfo;
        }

        public User CreateUser(RegisterViewModel model)
        {
            var user = new User { Name = model.Name, Email = model.Email, UserName = model.Email, Year = model.Year };

            return user;
        }
    }
}
