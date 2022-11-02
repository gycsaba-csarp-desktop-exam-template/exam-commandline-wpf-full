using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories.Interfaces;
using Kreta.Models.Context;
using Microsoft.EntityFrameworkCore;
using Kreta.Models.AbstractClass;

namespace Kreta.Repositories.BaseClass
{
    // https://code-maze.com/net-core-web-development-part4/
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : ClassWithId
    {
        private bool disposed = false;
        protected KretaContext KretaContext { get; set; }

        public RepositoryBase(KretaContext kretaContext)
        {
            KretaContext = kretaContext;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return KretaContext.Set<T>().Where(expression).AsNoTracking();
            //return KretaContext.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return KretaContext.Set<T>().AsNoTracking();
            //return KretaContext.Set<T>();
        }

        public long GetNextId()
        {
            var list = GetAll().ToList();
            var nextId = list.Select(x => x.Id).Max();
            if (nextId > 0)
                return nextId + 1;
            else
                return 1;
        }

        public T? Get(long id)
        {
            //return KretaContext.Set<T>().Find(id);
            var result = FindByCondition(x => x.Id == id);
            if (result != null)
                return result.FirstOrDefault();
            else
                return null;

        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                KretaContext.Set<T>().Add(entity);
                KretaContext.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            //KretaContext.Set<T>().AsNoTracking();
            if (entity != null)
            {
                KretaContext.Set<T>().Attach(entity);
                KretaContext.Entry(entity).State = EntityState.Detached;
                KretaContext.Set<T>().Update(entity);
                KretaContext.SaveChanges();
            }
        }


        public void Delete(int id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                KretaContext.Remove(entity);
                KretaContext.SaveChanges();
            }
        }

        public void Delete(T entyty)
        {
            if (entyty != null)
            {
                KretaContext.Set<T>().Remove(entyty);
                KretaContext.SaveChanges();
            }
        }

        public void DeleteAll()
        {
            /*foreach(var entity in GetAll())
            {
                Delete(entity);
            }*/
            throw new NotImplementedException();
        }

        public long Count()
        {
            var count = GetAll().Count();
            return count;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    KretaContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}

