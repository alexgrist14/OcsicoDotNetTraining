using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Interface;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Add(Employee emp)
        {
            var json = JsonSerializer.Serialize(emp);
            File.AppendAllText("employees.txt", json+Environment.NewLine);
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

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();


            var json = File.ReadAllText("employees.txt");
            var employee = JsonSerializer.Deserialize<Employee>(json);
            employees.Add(employee);

            return employees;
        }
    }
}
