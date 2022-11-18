using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeeMVCApplication.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var message = "OnResourceExecuted is called";
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var message = "OnResourceExecuting is called";
        }
    }
}
