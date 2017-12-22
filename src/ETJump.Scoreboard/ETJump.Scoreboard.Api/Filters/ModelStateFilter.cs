using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETJump.Scoreboard.Api.Exceptions;
using ETJump.Scoreboard.Core.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ETJump.Scoreboard.Api.Filters
{
    public class ModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new InvalidModelStateException(context.ModelState);
            }
        }
    }
}
