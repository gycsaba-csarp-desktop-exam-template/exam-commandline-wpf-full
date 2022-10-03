using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories.Interfaces;
using Kreta.Models.Context;
using Microsoft.EntityFrameworkCore;
using KretaParancssoriAlkalmazas.Models.AbstractClass;

namespace Kreta.Repositories.BaseClass
{
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
        }

        public long GetNextId()
        {
            var list = KretaContext.Set<T>().ToList();
            var nextId = list.Select(x => x.Id).Max();
            if (nextId > 0)
                return nextId+1;
            else
                return 1;
        }

        public T Get(long id)
        {
            return KretaContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return KretaContext.Set<T>().AsNoTracking();
        }

        public void Insert(T entity) => KretaContext.Set<T>().Add(entity);

        public void Update(T entity) => KretaContext.Set<T>().Update(entity);


        public void Delete(int id)
        {
            var entity = KretaContext.Set<T>().Find(id);
            if (entity != null)
            {
                KretaContext.Remove(entity);
                //KretaContext.SaveChanges();
            }
        }

        public void Delete(T entyty) => KretaContext.Set<T>().Remove(entyty);

        public void DeleteAll()
        {
            foreach(var entity in KretaContext.Set<T>())
            {
                Delete(entity);
            }
        }

        public long Count()
        {
            var count = KretaContext.Set<T>().Count();
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
