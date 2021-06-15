using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.ActionFilters
{
    public class AutenticationFilter : ActionFilterAttribute
    {
        public object HttpContext { get; private set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("LoggedUserId") == null)
                context.Result = new RedirectResult("/Home/Login");
        }
    }
}
