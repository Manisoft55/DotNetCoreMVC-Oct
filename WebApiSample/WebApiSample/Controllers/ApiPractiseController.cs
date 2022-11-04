using EmployeeManagement.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Net.Http;

namespace WebApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ApiPractiseController : ControllerBase
    {
        //[HttpGet]
        //public string GetString()
        //{
        //    return "Output";
        //}
        
        EmployeeEntityBL employeeEntityBL = new EmployeeEntityBL();

        //[HttpGet]
        //public string InputData(string inputVariable)
        //{
        //    return $"Your input data is {inputVariable}";
        //}

        [HttpGet]
        public DataTable GetAllEmployee()
        {
            var data = employeeEntityBL.GetAllEmployeeDetails().Tables[0];
            return data;
        }
    }
}
