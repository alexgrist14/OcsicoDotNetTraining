using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    public class NewsController : Controller
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        [HttpPost]
        public IActionResult Post(NewsViewModel model)
        {
            model.Id = Guid.NewGuid();
            model.Text = "И у меня работает";
            return Json(model);
        }
    }
}
