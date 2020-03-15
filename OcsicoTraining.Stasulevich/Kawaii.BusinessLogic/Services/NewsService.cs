using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kawaii.BusinessLogic.Services.Contracts;
using Kawaii.DataAccess.Context.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain;
using Kawaii.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Kawaii.BusinessLogic.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;
        private readonly IDataContext dataContext;

        public NewsService(INewsRepository newsRepository, IDataContext dataContext)
        {
            this.newsRepository = newsRepository;
            this.dataContext = dataContext;
        }

        public async Task<NewsViewModel> AddAsync(NewsViewModel model)
        {
            var news = new News() {
                Id = model.Id,
                Text = model.Text,
                Title = model.Title,
                IsSuccess = model.IsSuccess
            };

            await newsRepository.AddAsync(news);
            await dataContext.SaveChangesAsync();

            return model;
        }

        public async Task<List<NewsViewModel>> GetAsync()
        {
            var news = await newsRepository.GetQuery().ToListAsync();

            var newsViewModel = news
                .Select(x => new NewsViewModel { Text = x.Text, Title = x.Title })
                .ToList();

            return newsViewModel;
        }
    }
}
