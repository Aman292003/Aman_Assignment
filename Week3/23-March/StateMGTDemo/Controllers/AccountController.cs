using Microsoft.AspNetCore.Mvc;
using StateMGTDemo.Models;

namespace StateMGTDemo.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var cookieoptions = new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddMinutes(1)
            //    };
            //    Response.Cookies.Append("UserName", model.Username, cookieoptions);
            //    return RedirectToAction("Welcome");
            //}
            //return View(model);
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("UserName", model.Username);
                return RedirectToAction("Welcome");
            }
            return View(model);
        }
        
        public IActionResult Welcome()
        {

            //if (Request.Cookies.ContainsKey("UserName"))
            //{
            //    string username = Request.Cookies["UserName"];
            //    ViewBag.UserName = username;
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
            var username = HttpContext.Session.GetString("UserName");
            if (!String.IsNullOrEmpty(username))
            {
                ViewBag.UserName = username;
            }
            else
            {
                return RedirectToAction("Login");
            }
            ViewBag.UserName = username;
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // clears session
            return RedirectToAction("Login");

        }
        


    }
}
