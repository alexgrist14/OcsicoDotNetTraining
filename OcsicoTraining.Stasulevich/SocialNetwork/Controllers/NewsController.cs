using System;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Infrastructure.Hubs;

namespace SocialNetwork.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService newsService;
        private readonly IHubContext<NewsHub> hubContext;

        public NewsController(INewsService newsService, IHubContext<NewsHub> hubContext)
        {
            this.newsService = newsService;
            this.hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var news = await newsService.GetAsync();
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewsViewModel model)
        {
            model.Id = Guid.NewGuid();
            model.IsSuccess = true;

            await newsService.AddAsync(model);

            await this.hubContext.Clients.All.SendAsync("ReceiveMessage", model.Title, model.Text);

            return Json(model);
        }
    }
}
