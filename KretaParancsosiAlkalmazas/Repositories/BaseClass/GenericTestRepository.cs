using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;
using Kreta.Models.Interfaces.Base;

namespace Kreta.Repositories.BaseClass
{
    public class GenericTestRepository<TEntity, TRepository>  
        where TEntity : class
        where TRepository : List<TEntity>
    {
        protected TRepository repo;

        public virtual List<TEntity> GetAll()
        {
            return repo;
        }

        public virtual TEntity Get(int id)
        {
            return repo.ElementAt(id);
        }
      
        public virtual void Insert(TEntity entity)
        {
            repo.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            foreach(TEntity e in repo)
            {
                IBaseModel entityBase = (IBaseModel) entity;
                entityBase.Set(entity);
            }
            
            //TEntity search = repo.Find(e => (IBaseModel) e.Id==(IBaseModel) entity.Id);
        }

        public virtual void Delete(TEntity entity)
        {
            repo.Remove(entity);
        }


        public virtual void Delete(int id)
        {
            foreach (TEntity entity in repo)
            {
                IBaseModel baseEntity = (IBaseModel) entity;
                if (baseEntity.Id==id)
                {
                    repo.Remove(entity);
                    return;
                }
            }
        }
    }
}
