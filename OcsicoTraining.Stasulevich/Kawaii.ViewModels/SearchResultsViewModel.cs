using System;
using System.Collections.Generic;
using System.Text;

namespace Kawaii.ViewModels
{
    public class SearchResultsViewModel
    {
        public string SearchText { get; set; }

        public UsersListViewModel Users { get; set; }
    }
}
