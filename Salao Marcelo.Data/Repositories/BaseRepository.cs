using System;
using System.Collections.Generic;
using System.Linq;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Domain;

namespace Salao_Marcelo.Data.Repositories
{
    public class BaseRepository<T> where T: class, IEntity
    {
        protected Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll() => _context.Set<T>().ToList();

        public T Get(int id) => _context.Set<T>().FirstOrDefault(x => x.Id == id);

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Dispose() => _context.Dispose();
    }
}
