using System;
using System.Collections.Generic;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data.Interfaces
{
    public interface IBaseRepository<T> where T: class, IEntity
    {
        public void Add(T entity);
        public List<T> GetAll();
        public T Get(int id);
        public void Update(T entity);
        public void Remove(T entity);
        public void Dispose();
    }
}
