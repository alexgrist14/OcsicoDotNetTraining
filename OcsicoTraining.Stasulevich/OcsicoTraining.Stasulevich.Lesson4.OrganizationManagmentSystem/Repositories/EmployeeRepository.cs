using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string file = "employees.txt";

        public async Task AddAsync(Employee emp)
        {
            var json = JsonSerializer.Serialize(emp);
            await File.AppendAllTextAsync(file, json + Environment.NewLine);
        }

        public async void Remove(Employee emp)
        {
            var employees = GetAll();

            if (employees.Contains(emp))
            {
                employees.Remove(emp);
            }
            foreach (var e in employees)
            {
                var json = JsonSerializer.Serialize(e);
                await File.AppendAllTextAsync(file, json);
            }
        }

        public async void Update(Employee emp)
        {
            var employees = GetAll();

            if (employees.Contains(emp))
            {
                employees.Remove(emp);
                employees.Add(emp);
            }

            foreach (var e in employees)
            {
                var json = JsonSerializer.Serialize(e);
                await File.AppendAllTextAsync(file, json);
            }
        }

        public List<Employee> GetAll() => File.ReadAllLines(file)
                .Select(x => JsonSerializer.Deserialize<Employee>(x))
                .ToList();
    }
}
