using System;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.Domain.Identity;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        public PostsController(
            IPostService postService,
            IUserService userService,
            UserManager<User> userManager
            )
        {
            this.postService = postService;
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = new Guid(userManager.GetUserId(User));

            var posts = await postService.GetUserPosts(userId);

            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                await postService.CreateAsync(model, User);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
