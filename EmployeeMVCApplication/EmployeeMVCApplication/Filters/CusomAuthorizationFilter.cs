using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeeMVCApplication.Filters
{
    public class CusomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var message = "Authorization filter is executed";
        }
    }
}
