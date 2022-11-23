using EmployeeManagement.Model;
using EmployeeMVCApplication.Filters;
using EmployeeMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVCApplication.Controllers
{
    [CusomAuthorizationFilter]
    [CustomResourceFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [CustomActionFilter]
        [CustomResultFilter]
        public ViewResult Index()
        {
            return View();            
        }

        public JsonResult ReturnJson()
        {
            var author = new
            {
                FirstName = "Joydip",
                LastName = "Kanjilal",
                Address = "Hyderabad, INDIA"
            };
            return Json(author);
        }

        [Route("[controller]/ReturnHtmlData")]
        public ViewResult ReturnHtml()
        {
            var author = new
            {
                FirstName = "Joydip",
                LastName = "Kanjilal",
                Address = "Hyderabad, INDIA"
            };
            return View();
        }

        [ActionName("PrivacyDetails")]
        public RedirectResult PrivacyTCS()
        {
            return Redirect("https://www.tcs.com/");
        }

        public RedirectToActionResult Privacy()
        {
            TempData["EmailId"] = "TestOne@gmail.com";
            return RedirectToAction("AddEmployee");
            //return View();
        }

        public PartialViewResult PartialViewResult()
        {
            return PartialView("PartialView");
        }

        public RedirectToActionResult PrivacyInfo()
        {
            return RedirectToAction("ReturnHtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [NonAction]
        public string MyString()
        {
            return "Test";
        }

        public ViewResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddEmployee(EmployeeDetails employeeDetails)
        {
            HttpClient httpClient = new HttpClient();
            var data = new StringContent(JsonConvert.SerializeObject(employeeDetails), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("https://localhost:44366/employeeapi/ApiPractise/CreateEmployee", data).Result;
            var empId = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("GetEmployee");            
        }

        public ViewResult GetEmployee()
        {
            var empList = new List<EmployeeDetails>();
            using (HttpClient httpClient = new HttpClient())
            {
                var result = httpClient.GetAsync("https://localhost:44366/employeeapi/ApiPractise/SelectEmployeeDetails").Result;
                var response = result.Content.ReadAsStringAsync().Result;
                empList = JsonConvert.DeserializeObject<List<EmployeeDetails>>(response);
            }
            return View(empList);
        }

        public ViewResult EmployeeDetails()
        {
            return View();
        }
        
    }
}
