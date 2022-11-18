using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeeMVCApplication.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            var message = "OnResultExecuted is called";
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var message = "OnResultExecuting is called";
        }
    }
}
