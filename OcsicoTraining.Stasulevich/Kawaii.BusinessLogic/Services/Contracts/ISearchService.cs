using System.Security.Claims;
using Kawaii.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface ISearchService
    {
        public SearchResultsViewModel GetResults(string searchText, ClaimsPrincipal currentUser);
    }
}
