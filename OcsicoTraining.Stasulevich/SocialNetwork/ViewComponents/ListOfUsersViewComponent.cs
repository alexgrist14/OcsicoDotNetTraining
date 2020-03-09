using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.ViewComponents
{
    [ViewComponent(Name = "ListOfUsers")]
    public class ListOfUsersViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(UsersListViewModel viewModel)
        {
            if(viewModel == null)
            {
                viewModel = new UsersListViewModel();
            }

            return View(viewModel);
        }
    }
}
