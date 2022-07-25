using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace Kreta.Repositories.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable
        where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
