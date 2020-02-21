using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class EmployeeOrganizationRoleRepository : IEmployeeOrganizationRoleRepository
    {
        private readonly string file = "employeeOrganizationRole.txt";

        public async Task AddAsync(EmployeeOrganizationRole entity)
        {
            var json = JsonSerializer.Serialize(entity);
            await File.AppendAllTextAsync(file, json + Environment.NewLine);
        }

        public List<EmployeeOrganizationRole> GetAll() => File.ReadAllLines(file)
            .Select(x => JsonSerializer.Deserialize<EmployeeOrganizationRole>(x))
            .ToList();

        public void Remove(EmployeeOrganizationRole entity)
        {
            var entities = GetAll();

            entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);

            foreach (var e in entities)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllTextAsync(file, json);
            }
        }

        public void Update(EmployeeOrganizationRole entity)
        {
            var entities = GetAll();

            entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);
            entities.Add(entity);

            foreach (var e in entities)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllTextAsync(file, json);
            }
        }
    }
}
