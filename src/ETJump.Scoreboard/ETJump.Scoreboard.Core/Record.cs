using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ETJump.Scoreboard.Utilities;

namespace ETJump.Scoreboard.Core
{
    public class Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("time")]
        public int Time { get; set; }
        [NotMapped]
        public DateTime RecordDate {
            get => InternalRecordDate.FromUnixTimestamp();
            set => InternalRecordDate = value.ToUnixTimestamp();
        }
        [Column("record_date")]
        public int InternalRecordDate { get; set; }
        [Column("map")]
        public string Map { get; set; }
        [Column("run")]
        public string Run { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("player_name")]
        public string PlayerName { get; set; }
        [NotMapped]
        public List<int> CheckpointTimes { get; set; }
        [NotMapped]
        public Season Season { get; set; }
    }
}
