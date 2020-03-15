using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Kawaii.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface IPostService
    {
        Task CreateAsync(PostViewModel viewModel, ClaimsPrincipal user);

        Task<List<PostViewModel>> GetUserPosts(Guid userId);

        void DeletePost(Guid id, ClaimsPrincipal user);
    }
}
