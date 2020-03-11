using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index(string searchText)
        {
            var viewModel = searchService.GetResults(searchText, User);

            return View(viewModel);
        }
    }
}
