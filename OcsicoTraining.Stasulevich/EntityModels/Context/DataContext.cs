using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EntityModels.Context.Contracts;
using EntityModels.Contracts;
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
