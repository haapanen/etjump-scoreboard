using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETJump.Scoreboard.Api.Models
{
    public class RecordModel
    {
        public int Time { get; set; }
        public DateTime RecordDate { get; set; }
        public string Map { get; set; }
        public string Run { get; set; }
        public string PlayerName { get; set; }
        public List<int> CheckpointTimes { get; set; }
    }
}
