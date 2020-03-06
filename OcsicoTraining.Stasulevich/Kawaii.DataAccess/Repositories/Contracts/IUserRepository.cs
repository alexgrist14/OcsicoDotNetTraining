using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain.Identity;

namespace Kawaii.DataAccess.Repositories.Contracts
{
    public interface IUserRepository : IAppEntityRepository<User>
    {
    }
}
