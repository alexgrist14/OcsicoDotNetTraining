using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Interface;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Repositories
{
    public class StagingEntityRepository : IStagingEntityRepository
    {
        public void Add(StagingEntity entity)
        {
            var json = JsonSerializer.Serialize(entity);
            File.AppendAllText("stagingEntity.txt", json + Environment.NewLine);
        }

        public List<StagingEntity> GetAll() => File.ReadAllLines("stagingEntity.txt")
            .Select(x => JsonSerializer.Deserialize<StagingEntity>(x))
            .ToList();

        public void Remove(StagingEntity entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);

            foreach (var e in entities)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllText("stagingEntity.txt", json);
            }
        }

        public void Update(StagingEntity entity)
        {
            var entities = GetAll();

            _ = entities.RemoveAll(e => e.EmployeeId == entity.EmployeeId && e.OrganizationId == entity.OrganizationId && e.RoleId == entity.RoleId);
            entities.Add(entity);

            foreach (var e in entities)
            {
                var json = JsonSerializer.Serialize(e);
                File.AppendAllText("stagingEntity.txt", json);
            }
        }
    }
}
