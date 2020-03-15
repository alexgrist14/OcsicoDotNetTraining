using System;
using System.Threading.Tasks;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using SocialNetwork.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        Task<UserInfoViewModel> GetAsync(Guid id);

        UserInfoViewModel GetUserInfo(Guid userId, Guid currentUserId);

        User CreateUser(RegisterViewModel model);
    }
}
