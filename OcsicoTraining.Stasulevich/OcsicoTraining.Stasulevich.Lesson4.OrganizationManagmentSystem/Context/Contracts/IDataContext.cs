using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Models.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IAppEntity<Guid>;

        Task<int> SaveChangesAsync();
    }
}
