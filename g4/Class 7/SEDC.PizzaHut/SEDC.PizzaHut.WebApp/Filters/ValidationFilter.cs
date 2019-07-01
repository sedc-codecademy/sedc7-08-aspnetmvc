using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaHut.WebApp.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                IEnumerable<string> errorMessages = context.ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(m => m.ErrorMessage);

                var errorsConcatenated = string.Join(',', errorMessages);

                throw new Exception(errorsConcatenated);
            }
        }
    }
}
