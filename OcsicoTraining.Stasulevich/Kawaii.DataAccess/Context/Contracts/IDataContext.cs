using System;
using System.Threading.Tasks;
using Kawaii.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Kawaii.DataAccess.Context.Contracts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IEntityModel<Guid>;

        Task<int> SaveChangesAsync();
    }
}
