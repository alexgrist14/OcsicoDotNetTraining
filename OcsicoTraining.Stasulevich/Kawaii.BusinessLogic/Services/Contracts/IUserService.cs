using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kawaii.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        Task<UserInfoViewModel> GetAsync(Guid id);

        Task<UserInfoViewModel> GetUserInfo(Guid id);
    }
}
