using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IDataContext dataContext;
        private readonly UserManager<User> userManager;

        public PostService(
            IPostRepository postRepository,
            IDataContext dataContext,
            UserManager<User> userManager)
        {
            this.postRepository = postRepository;
            this.dataContext = dataContext;
            this.userManager = userManager;
        }

        public async Task CreateAsync(PostViewModel model, ClaimsPrincipal user)
        {
            var userId = new Guid(userManager.GetUserId(user));

            var post = new Post
            {
                UserId = userId,
                Content = model.Content,
            };

            await postRepository.AddAsync(post);
            await dataContext.SaveChangesAsync();
        }

        public void DeletePost(Guid id, ClaimsPrincipal user)
        {
            var post = postRepository.GetQuery().FirstOrDefault(x => x.Id == id);
            var currentUser = userManager.GetUserAsync(user).GetAwaiter().GetResult();

            if (post == null)
            {
                return;
            }

            postRepository.Remove(post);
            dataContext.SaveChangesAsync();
        }

        public async Task<List<PostViewModel>> GetUserPosts(Guid userId)
        {
            var posts = await postRepository.GetQuery().Where(x => x.UserId == userId).ToListAsync();

            return posts
                .Select(x => new PostViewModel { Id = x.Id, Content = x.Content, CreatedOn = x.CreatedOn })
                .ToList();
        }
    }
}
