using System;
using System.Threading.Tasks;
using Kawaii.DataAccess.Context;
using Kawaii.DataAccess.Context.Contracts;
using Kawaii.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EntityModels.Context
{
    public class DataContext : IDataContext
    {
        private readonly ApplicationContext applicationContext;

        public DataContext(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public Task<int> SaveChangesAsync() => applicationContext.SaveChangesAsync();

        public DbSet<T> Set<T>() where T : class, IEntityModel<Guid> => applicationContext.Set<T>();
    }
}
