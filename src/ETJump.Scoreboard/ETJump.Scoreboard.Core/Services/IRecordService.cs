using System;
using System.Collections.Generic;
using System.Text;
using ETJump.Scoreboard.Core.QueryCriteria;

namespace ETJump.Scoreboard.Core.Services
{
    public interface IRecordService
    {
        IEnumerable<Record> GetRecords(RecordCriteria criteria);
    }
}
