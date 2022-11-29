using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MVCwithEFCoreV3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwithEFCoreV3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            string path = @"D:\Aimore\UploadedFiles\";
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    // full path to file in temp location
                    var filePath = path + formFile.FileName; //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }

        public IActionResult RadioAndDropDown()
        {
            // Radio button
            var vm = new CreateUserVm
            {
                Roles = new List<RoleVm>
                {
                    new RoleVm {Id = 1, RoleName = "Admin"},
                    new RoleVm {Id = 2, RoleName = "Editor"},
                    new RoleVm {Id = 3, RoleName = "Reader"}
                }
            };

            // Dropdown
            List<SelectListItem> cities = new List<SelectListItem>();
            cities.Add(new SelectListItem { Value = "11", Text = "Chennai" });
            cities.Add(new SelectListItem { Value = "1", Text = "Latur" });
            cities.Add(new SelectListItem { Value = "2", Text = "Solapur" });
            cities.Add(new SelectListItem { Value = "3", Text = "Nanded" });
            cities.Add(new SelectListItem { Value = "4", Text = "Nashik" });
            cities.Add(new SelectListItem { Value = "5", Text = "Nagpur" });
            cities.Add(new SelectListItem { Value = "6", Text = "Kolhapur" });
            cities.Add(new SelectListItem { Value = "7", Text = "Pune" });
            cities.Add(new SelectListItem { Value = "8", Text = "Mumbai" });
            cities.Add(new SelectListItem { Value = "9", Text = "Delhi" });
            cities.Add(new SelectListItem { Value = "10", Text = "Noida" });
            

            //assigning SelectListItem to view Bag
            ViewBag.cities = cities;
            return View(vm);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class CreateUserVm
    {
        public string UserName { set; get; } //Rajesh
        public IEnumerable<RoleVm> Roles { set; get; } // Editor, Reader
        public int SelectedRole { set; get; } // Editor - Selected Role
    }
    public class RoleVm
    {
        public int Id { set; get; }
        public string RoleName { set; get; }
    }

}
