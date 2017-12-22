using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ETJump.Scoreboard.Api.Models;
using ETJump.Scoreboard.Core;

namespace ETJump.Scoreboard.Api.AutoMapper
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Record, RecordModel>();
        }
    }
}
