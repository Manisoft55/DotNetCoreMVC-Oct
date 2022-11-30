using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVCwithEFCoreV3.Models;
using System.Security.Claims;

namespace MVCwithEFCoreV3.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            var userName = userLogin.UserName;
            var password = userLogin.Password;
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            //Check the user name and password  
            //Here can be implemented checking logic from the database  
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            if (userName == "Mani" && password == "Password@123")
            {

                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (userName == "Rajesh" && password == "Password@123")
            {

                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (userName == "Kumar" && password == "Password@123")
            {
                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, "Receptionist")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }

            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                // Below line set that user is getting logging in to the application
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Employees");
            }
            else
            {
                ViewBag.ErrorMessage = "Please enter valid user name and password";
            }

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
