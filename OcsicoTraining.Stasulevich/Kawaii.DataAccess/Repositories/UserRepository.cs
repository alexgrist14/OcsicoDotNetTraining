using Kawaii.DataAccess.Context.Contracts;
using Kawaii.DataAccess.Repositories.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.DataAccess.Repositories
{
    public class UserRepository : AppEntityRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
