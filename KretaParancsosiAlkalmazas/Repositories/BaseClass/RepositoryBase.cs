using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Kreta.Repositories.Interfaces;
using Kreta.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Repositories.BaseClass
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
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
                KretaContext.SaveChanges();
            }
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
