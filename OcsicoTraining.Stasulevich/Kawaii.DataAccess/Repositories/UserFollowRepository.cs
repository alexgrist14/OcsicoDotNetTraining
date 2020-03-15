using Kawaii.DataAccess.Context.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain;

namespace Kawaii.DataAccess.Repositories
{
    public class UserFollowRepository : AppEntityRepository<UserFollow>, IUserFollowRepository
    {
        public UserFollowRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
