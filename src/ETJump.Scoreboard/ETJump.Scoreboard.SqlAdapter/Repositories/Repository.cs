using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETJump.Scoreboard.Core.Repositories;

namespace ETJump.Scoreboard.SqlAdapter.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext DbContext;

        public Repository(ApplicationContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return DbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
        }

        public Task SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
