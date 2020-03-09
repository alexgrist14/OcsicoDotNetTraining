using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class UsersProfilesController : Controller
    {
        private readonly IUserService userService;
        private readonly ISubscriptionsService subscriptionsService;
        private readonly UserManager<User> userManager;

        public UsersProfilesController(IUserService userService, ISubscriptionsService subscriptionsService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.subscriptionsService = subscriptionsService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Index(Guid userId)
        {
            var currentUserId = new Guid(userManager.GetUserId(User));

            if (currentUserId == userId)
            {
                return RedirectToAction("MyProfile", "Profile");
            }

            //var currentUserId = userManager.GetUserId(User);
            var viewModel = new PostsFeedAndUserInfoViewModel()
            {
                CurrentUserInfo = userService.GetUserInfo(userId),
            };

            if(viewModel.CurrentUserInfo == null)
            {
                var result = View("Error", ModelState);
                result.StatusCode = (int)HttpStatusCode.NotFound;

                return result;
            }

            return View(viewModel);
        }
    }
}
