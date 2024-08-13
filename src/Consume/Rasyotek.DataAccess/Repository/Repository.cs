using Microsoft.EntityFrameworkCore;
using Rasyotek.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PersonelContext _context;

        public Repository(PersonelContext context)
        {
            _context = context;
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList(); 
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
