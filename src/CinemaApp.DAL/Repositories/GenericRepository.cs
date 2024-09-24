using CinemaApp.Core.Entities.Base;
using CinemaApp.Core.Repositories;
using CinemaApp.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private AppDBContext _context;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public async Task CreateAsync(TEntity entity) => await Table.AddAsync(entity);
        
        public void Delete(TEntity entity) => Table.Remove(entity);

        public IQueryable<TEntity> GetByExperssion(Expression<Func<TEntity, bool>> expression, bool asNoTracking, params string[] includes)
        {
            var query = Table.AsQueryable();
            if (includes.Length > 0) 
            {
                foreach (var include in includes)
                {
                    query= query.Include(include);
                }
            }
            query = asNoTracking == true ? query.Where(expression) : query;

            return expression is not null ? query.Where(expression) : query;
        }

        public async Task<TEntity> GetbyId(int id)
        {
            return await Table.FindAsync(id);
        }
    }
}

