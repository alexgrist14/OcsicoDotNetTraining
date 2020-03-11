using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Kawaii.BusinessLogic.Services
{
    public class SearchService : ISearchService
    {
        private readonly IUserRepository userRepository;
        private readonly IFollowService followService;
        private readonly UserManager<User> userManager;

        public SearchService(IUserRepository userRepository, IFollowService followService, UserManager<User> userManager)
        {
            this.userRepository = userRepository;
            this.followService = followService;
            this.userManager = userManager;
        }

        public SearchResultsViewModel GetResults(string searchText, ClaimsPrincipal currentUser)
        {
            var currentUserId = new Guid(userManager.GetUserId(currentUser));
            var result = new SearchResultsViewModel
            {
                SearchText = searchText
            };

            var users = userRepository.GetQuery()
                .Where(x => x.Name.Contains(searchText))
                .Select(x => new UserViewModel { Id = x.Id, UserName = x.Name})
                .ToList();

            foreach(var user in users)
            {
                user.IsFollowingCurrentUser = followService.IsBeingFollowedBy(user.Id, currentUserId);
            }

            result.Users = new UsersListViewModel()
            {
                Users = users
            };

            return result;
        }
    }
}
