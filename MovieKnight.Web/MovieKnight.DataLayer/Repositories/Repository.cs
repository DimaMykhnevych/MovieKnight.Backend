using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MovieKnightDbContext Context;
        public Repository(MovieKnightDbContext context)
        {
            Context = context;
        }
        public async Task<TEntity> Get(Guid id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            //Context.Entry(entity).State = EntityState.Modified;
            Context.Set<TEntity>().Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
}
