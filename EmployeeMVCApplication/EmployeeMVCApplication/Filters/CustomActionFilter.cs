using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeeMVCApplication.Filters
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var message = "OnActionExecuted is called";
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var message = "OnActionExecuting is called";
        }
    }
}
