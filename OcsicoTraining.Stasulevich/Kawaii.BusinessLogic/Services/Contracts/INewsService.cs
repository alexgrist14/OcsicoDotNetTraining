using System.Collections.Generic;
using System.Threading.Tasks;
using Kawaii.ViewModels;

namespace Kawaii.BusinessLogic.Services.Contracts
{
    public interface INewsService
    {
        public Task<NewsViewModel> AddAsync(NewsViewModel model);

        public Task<List<NewsViewModel>> GetAsync();
    }
}
