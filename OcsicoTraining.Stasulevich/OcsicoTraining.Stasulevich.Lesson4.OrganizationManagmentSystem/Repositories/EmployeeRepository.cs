using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee emp)
        {
            var json = JsonSerializer.Serialize(emp);
            File.AppendAllText("employees.txt", json + Environment.NewLine);
        }

        public void Remove(Employee emp)
        {
            var employees = GetAll();

            if (employees.Contains(emp))
            {
                _ = employees.Remove(emp);
            }
            foreach (var e in employees)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllText("employees.txt", json);
            }
        }

        public void Update(Employee emp)
        {
            var employees = GetAll();

            if (employees.Contains(emp))
            {
                _ = employees.Remove(emp);
                employees.Add(emp);
            }

            foreach (var e in employees)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllText("employees.txt", json);
            }
        }

        public List<Employee> GetAll() => File.ReadAllLines("employees.txt")
                .Select(x => JsonSerializer.Deserialize<Employee>(x))
                .ToList();
    }
}
