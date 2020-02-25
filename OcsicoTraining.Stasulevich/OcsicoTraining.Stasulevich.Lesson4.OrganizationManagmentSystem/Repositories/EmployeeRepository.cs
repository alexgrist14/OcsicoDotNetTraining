using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Context.Contracts;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeRepository<T> : IEmployeeRepository 
    {
        private readonly string file = "employees.txt";
        protected DbSet<Employee> EntitiesSet { get; private set; }

        public EmployeeRepository(IDataContext dataContext)
        {
            EntitiesSet = dataContext.Set<T>();
        }

        public async Task AddAsync(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            EntitiesSet.Attach(emp);
            EntitiesSet.Add(emp);
        }

        public IQueryable<Employee> GetQuery() => EntitiesSet;

        public void Remove(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            EntitiesSet.Attach(emp);
            EntitiesSet.Remove(emp);
        }

        public void Remove(Guid id)
        {
            var employee = EntitiesSet.FirstOrDefault(x => x.Id == id);
            Remove(employee);
        }

        public void Update(Employee emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            EntitiesSet.Attach(emp);
            EntitiesSet.Update(emp);
        }

        public List<Employee> GetAll() => File.ReadAllLines(file)
                .Select(x => JsonSerializer.Deserialize<Employee>(x))
                .ToList();
    }
}
