﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSmArtLock.Models;
using Microsoft.EntityFrameworkCore;

namespace ERPSmArtLock.Data.Repositories
{
    public abstract class DataRepository<TEntity, TContext> : IDataRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        // attribute context data base 
        private readonly TContext context;
        // constructor
        public DataRepository(TContext context)
        {
            this.context = context;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

    }
}
