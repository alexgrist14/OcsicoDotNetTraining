using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Contracts;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly string file = "organizations.txt";

        public async Task AddAsync(Organization entity)
        {
            var json = JsonSerializer.Serialize(entity);
            await File.AppendAllTextAsync(file, json + Environment.NewLine);
        }

        public List<Organization> GetAll() => File.ReadAllLines(file)
            .Select(x => JsonSerializer.Deserialize<Organization>(x))
            .ToList();

        public void Remove(Organization entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.Id == entity.Id);

            foreach (var e in entities)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllTextAsync(file, json);
            }
        }

        public void Update(Organization entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.Id == entity.Id);
            entities.Add(entity);

            foreach (var e in entities)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllTextAsync(file, json);
            }
        }
    }
}
