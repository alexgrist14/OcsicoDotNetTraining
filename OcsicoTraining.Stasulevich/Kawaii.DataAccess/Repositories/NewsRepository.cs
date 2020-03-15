using Kawaii.DataAccess.Context.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain;

namespace Kawaii.DataAccess.Repositories
{
    public class NewsRepository : AppEntityRepository<News>, INewsRepository
    {
        public NewsRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
