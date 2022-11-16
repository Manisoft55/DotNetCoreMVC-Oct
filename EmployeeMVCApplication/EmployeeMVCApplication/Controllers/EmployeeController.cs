using Microsoft.AspNetCore.Mvc;

namespace EmployeeMVCApplication.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[controller]/EmployeeTestMehod")]
        [Route("[controller]/EmployeeTestMehodOne")]
        public IActionResult Test()
        {
            return View();
        }
    }
}
