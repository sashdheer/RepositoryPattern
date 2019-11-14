using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPattern.Repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
    }
}