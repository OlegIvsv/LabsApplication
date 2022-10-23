﻿using LabsApplication.UnitOfWork.EF;
using LabsApplication.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LabsApplication.UnitOfWork.Repositories
{
    public abstract class BaseRepository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected AppDbContext dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public IList<TEntity> List()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public IList<TEntity> List(Expression<Func<TEntity, bool>> expression)
        {
            return dbContext.Set<TEntity>()
                .Where(expression)
                .ToList();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
