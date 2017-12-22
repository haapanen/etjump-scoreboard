using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETJump.Scoreboard.Core.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetQueryable();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        Task SaveChangesAsync();
    }
}
