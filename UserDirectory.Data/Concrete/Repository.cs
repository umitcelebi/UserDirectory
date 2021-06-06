using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserDirectory.Data.Abstract;

namespace UserDirectory.Data.Concrete
{
    public class Repository<T>:IRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            dbContext.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
