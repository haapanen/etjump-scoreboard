using System;
using System.Collections.Generic;
using System.Text;
using ETJump.Scoreboard.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ETJump.Scoreboard.SqlAdapter
{
    

    public class ApplicationContext : DbContext
    {
        private readonly string _database;
        public static readonly LoggerFactory _LoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public ApplicationContext(string database)
        {
            if (string.IsNullOrEmpty(database))
            {
                throw new ArgumentNullException(nameof(database));
            }

            _database = database;
        }

        public DbSet<Record> Records { get; set; }
        //public DbSet<Season> Seasons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(_LoggerFactory)
                .UseSqlite($"Data Source={_database}");
        }
    }
}
