using CinemaApp.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get;} 
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity); 
        IQueryable<TEntity> GetByExperssion(Expression<Func<TEntity,bool>>expression,bool asNoTracking,params string[] includes);
        Task<TEntity> GetbyId(int id);
        Task<int> CommitAsync();
    }
}
