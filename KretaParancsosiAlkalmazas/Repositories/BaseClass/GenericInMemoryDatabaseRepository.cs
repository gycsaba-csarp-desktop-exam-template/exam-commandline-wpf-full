using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Repositories.BaseClass
{
    public class GenericInMemoryDatabaseRepository<TEntity, TContext> : IGenericRepository<TEntity> 
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext context;
        public GenericInMemoryDatabaseRepository(TContext context)
        {
            this.context = context;
        }
        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);   
        }
      
        public virtual void Insert(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

        public virtual void Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}
