using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using SocialNetwork.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        Task<UserInfoViewModel> GetAsync(Guid id);

        UserInfoViewModel GetUserInfo(Guid id);

        User CreateUser(RegisterViewModel model);
    }
}
