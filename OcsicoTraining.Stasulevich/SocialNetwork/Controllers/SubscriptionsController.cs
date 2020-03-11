using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace SocialNetwork.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly IFollowService followService;

        public SubscriptionsController(IFollowService subscriptionsService)
        {
            this.followService = subscriptionsService;
        }

        public IActionResult WhoToFollow(int? page)
        {
            var viewModel = new UsersListViewModel() { NoUsersWord = "mode users left to follow" };
            var pageNumber = page ?? 1;
            ViewBag.PageNum = pageNumber;
            var usersToFollow = followService.GetUsersToFollow(User);

            viewModel.Users = usersToFollow.ToPagedList(pageNumber, 10);

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChooseAction(Guid userId, string action)
        {
            var currentUserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (action == "follow")
            {
                followService.Follow(userId, currentUserId);
            }
            else if (action == "unfollow")
            {
                followService.Unfollow(userId, currentUserId);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        public IActionResult Followers(int? page)
        {
            var pageNumber = page ?? 1;
            var followers = followService.GetFollowers(User);

            ViewBag.PageNum = pageNumber;

            var viewModel = new UsersListViewModel { Users = followers.ToPagedList(pageNumber, 10), NoUsersWord = "followers" };

            ViewData["FollowersCount"] = followers.Count;

            return View(viewModel);
        }

        public IActionResult Following(int? page)
        {
            var pageNumber = page ?? 1;
            var followings = followService.GetFollowings(User);
            ViewBag.PageNum = pageNumber;

            var viewModel = new UsersListViewModel { Users = followings.ToPagedList(pageNumber, 10), NoUsersWord = "followings" };

            ViewData["FollowingsCount"] = followings.Count;

            return View(viewModel);
        }
    }
}
