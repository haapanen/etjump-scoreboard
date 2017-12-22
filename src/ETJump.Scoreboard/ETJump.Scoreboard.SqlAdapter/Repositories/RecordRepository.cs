using System;
using System.Collections.Generic;
using System.Text;
using ETJump.Scoreboard.Core;
using ETJump.Scoreboard.Core.Repositories;

namespace ETJump.Scoreboard.SqlAdapter.Repositories
{
    internal class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
