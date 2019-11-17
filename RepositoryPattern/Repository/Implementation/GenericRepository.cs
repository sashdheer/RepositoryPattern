using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RepositoryPattern.Repository.Interface;
using RepositoryPattern.ViewModel;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository.Implementation
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class
    {
        public SampleDBEntities context;
        public DbSet<TEntity> dbset;
        public GenericRepository(SampleDBEntities context)
        {
            this.context = context;
            dbset = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return dbset.Find(id);
        }


        public IQueryable<TEntity> GetAll()
        {
            return dbset;
        }

        public void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }


        public void Update(TEntity entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }
    }
}