using Kreta.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Repositories.BaseClass
{
    public class GenericTestRepository<TEntity>  
        where TEntity : class
    {

        public virtual List<TEntity> GetAll()
        {
            return null;
        }

        public virtual TEntity Get(int id)
        {
            return null;
        }
      
        public virtual void Insert(TEntity entity)
        {
        }

        public virtual void Update(TEntity entity)
        {
        }

        public virtual void Delete(int id)
        {
        }

        public virtual void Save()
        {
        }
    }
}
