using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAuthentication.Models;

namespace WebAuthentication.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //check if not in development

            if (!context.ExceptionHandled)
            {
                //in real scenario the exception will be logged (in file/database)
                var result = new ViewResult() { ViewName = "Error" };
                context.Result = result;
            }

            

            

            //base.OnException(context);
        }
    }
}
