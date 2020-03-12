using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IFollowService followService;
        private readonly UserManager<User> userManager;

        public ProfileController(IUserService userService, IFollowService subscriptionsService, UserManager<User> userManager)
        {
            this.followService = subscriptionsService;
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyProfile(MyProfileViewModel viewModel)
        {
            var userId = new Guid(userManager.GetUserId(User));

            var userInfoView = new MyProfileViewModel
            {
                UserInfo = userService.GetUserInfo(userId, userId),
            };

            return View(userInfoView);
        }
    }
}
