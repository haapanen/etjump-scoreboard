using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ETJump.Scoreboard.Api.Exceptions
{
    public class InvalidModelStateException : Exception
    {
        public ModelStateDictionary ModelState { get; set; }

        public InvalidModelStateException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }
    }
}
