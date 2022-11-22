﻿using EmployeeManagement.Model;
using EmployeeMVCApplication.Filters;
using EmployeeMVCApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var empDetails = new EmployeeDetails() { EmployeeFirstName = "Raj", EmployeeLastName = "Kumar" };
            ViewBag.EmailId = Convert.ToString(TempData["EmailId"]);
            TempData.Peek("EmailId");
            TempData.Keep("EmailId");
            ViewData["PhoneNumber"] = "962611111";
            return View(empDetails);
        }

        public ViewResult EmployeeDetails()
        {
            return View();
        }
        
    }
}
