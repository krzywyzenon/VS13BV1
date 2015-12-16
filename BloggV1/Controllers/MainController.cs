using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using BloggV1.Models;

namespace BloggV1.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Login() 
        {
            ViewBag.logged = false;
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            User user;
            bool matchFound = false;
            using (BloggV1Connection db = new BloggV1Connection())
            {
                user = db.Users.SingleOrDefault(x=>x.Username == u.Username && x.Password == u.Password);
            }


            if (user != null)
            {
                matchFound = true;
            }

            if (matchFound)
            {
                
                ViewBag.logged = true;
                ViewBag.test = u.Username;
                return View(user);
            }
            else
            {
                ViewBag.ErrorMessage = "Login invalid";
                ViewBag.logged = false;
                return View(); 
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}