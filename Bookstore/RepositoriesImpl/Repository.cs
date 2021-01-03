using Bookstore.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookstore.RepositoriesImpl
{
    public class Repository<TEntity> : Repositories.IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public TEntity Get(int? id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}