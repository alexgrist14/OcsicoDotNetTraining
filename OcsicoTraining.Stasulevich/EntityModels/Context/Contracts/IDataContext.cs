using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EntityModels.Context.Contracts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IEntityModel<Guid>;

        Task<int> SaveChangesAsync();
    }
}
