using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public string InputData(string inputVariable)
        {
            return $"Your input data is {inputVariable}";
        }
    }
}
