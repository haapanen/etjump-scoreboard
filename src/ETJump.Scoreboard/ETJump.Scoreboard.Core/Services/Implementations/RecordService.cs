using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETJump.Scoreboard.Core.QueryCriteria;
using ETJump.Scoreboard.Core.Repositories;

namespace ETJump.Scoreboard.Core.Services.Implementations
{
    internal class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public IEnumerable<Record> GetRecords()
        {
            return _recordRepository.GetQueryable();
        }

        public IEnumerable<Record> GetRecords(RecordCriteria criteria)
        {
            var query = _recordRepository.GetQueryable()
                .Where(r => r.Map == criteria.Map);

            return query
                .OrderBy(r => r.Time)
                .Skip(criteria.Offset)
                .Take(criteria.Limit);
        }
    }
}
