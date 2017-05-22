using System;
using System.Linq;
using System.Threading.Tasks;
using CelebritiesAPI.Core.EntityLayer;
using CelebritiesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CelebritiesAPI.Core.DataLayer
{
    public class CelebritiesRepository : ICelebritiesRepository
    { 
        private readonly CelebritesDbContext DbContext;
        private Boolean Disposed;

        public CelebritiesRepository(CelebritesDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();

                    Disposed = true;
                }
            }
        }

        public IQueryable<Celebrity> GetCelebrities()
        {
            var query = DbContext.Set<Celebrity>();

            return query;
        }

        public Task<Celebrity> GetCelebrityAsync(Celebrity entity)
        {
            return DbContext.Set<Celebrity>().FirstOrDefaultAsync(item => item.ID == entity.ID);
        }

        public async Task<Celebrity> AddCelebrityAsync(Celebrity entity)
        {

            DbContext.Set<Celebrity>().Add(entity);

            await DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Celebrity> UpdateCelebrityAsync(Celebrity changes)
        {
            var entity = await GetCelebrityAsync(changes);

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Age = changes.Age;
                entity.Country = changes.Country;

             await DbContext.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<Celebrity> DeleteCelebrityAsync(Celebrity changes)
        {
            var entity = await GetCelebrityAsync(changes);

            if (entity != null)
            {
                DbContext.Set<Celebrity>().Remove(entity);

                await DbContext.SaveChangesAsync();
            }

            return entity;
        }
    }
}
