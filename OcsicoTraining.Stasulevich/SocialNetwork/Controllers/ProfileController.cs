using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public ProfileController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            var userId = new Guid(userManager.GetUserId(User));

            var userInfoView = new MyProfileViewModel
            {

                CurrentUserInfo = await userService.GetUserInfo(userId)

            };

            return View(userInfoView);
        }
    }
}
