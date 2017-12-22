using System;
using System.Collections.Generic;
using System.Text;

namespace ETJump.Scoreboard.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
