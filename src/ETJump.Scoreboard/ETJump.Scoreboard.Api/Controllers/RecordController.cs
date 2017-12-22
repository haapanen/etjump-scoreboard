using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETJump.Scoreboard.Api.Models;
using ETJump.Scoreboard.Core.QueryCriteria;
using ETJump.Scoreboard.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETJump.Scoreboard.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/records")]
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly IMapper _mapper;

        public RecordController(IRecordService recordService, IMapper mapper)
        {
            _recordService = recordService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<RecordModel> GetRecords(RecordCriteria criteria)
        {
            return _recordService.GetRecords(criteria).Select(_mapper.Map<RecordModel>);
        }
    }
}