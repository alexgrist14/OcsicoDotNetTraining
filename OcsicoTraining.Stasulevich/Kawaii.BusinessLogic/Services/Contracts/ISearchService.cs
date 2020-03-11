using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Kawaii.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface ISearchService
    {
        public SearchResultsViewModel GetResults(string searchText, ClaimsPrincipal currentUser);
    }
}
