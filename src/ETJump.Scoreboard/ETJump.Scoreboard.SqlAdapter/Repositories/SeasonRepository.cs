using System;
using System.Collections.Generic;
using System.Text;
using ETJump.Scoreboard.Core;
using ETJump.Scoreboard.Core.Repositories;

namespace ETJump.Scoreboard.SqlAdapter.Repositories
{
    internal class SeasonRepository : Repository<Season>, ISeasonRepository
    {
        public SeasonRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
