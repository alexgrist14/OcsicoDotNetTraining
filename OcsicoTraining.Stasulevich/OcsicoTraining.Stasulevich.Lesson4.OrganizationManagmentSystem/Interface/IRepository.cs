using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson4.OrganizationManagmentSystem.Interface
{
    public interface IRepository<T> where T: class
    {
        public void Add(T entity);
        public void Remove(T entity);
        public void Update(T entity);
        public List<T> GetAll();
    }
}
