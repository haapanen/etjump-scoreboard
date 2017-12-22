using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ETJump.Scoreboard.Core.QueryCriteria
{
    public class RecordCriteria
    {
        [Required]
        public string Map { get; set; }
        public int Limit { get; set; } = 50;
        public int Offset { get; set; } = 0;
    }
}
