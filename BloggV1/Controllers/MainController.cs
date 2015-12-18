using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls.WebParts;
using BloggV1.Models;

namespace BloggV1.Controllers
{//TODO Ograniczniki na ilosc tekstu (moze jakis licznik znakow)
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
            int id=-1;
            using (BloggV1Connection db = new BloggV1Connection())
            {
                user = db.Users.SingleOrDefault(x=>x.Username == u.Username && x.Password == u.Password);
            }


            if (user != null)
            {
                matchFound = true;
                id = user.UserId;
            }

            if (matchFound)
            {
                
                ViewBag.logged = true;
                ViewBag.test = u.Username;
                Checking.IsAuthorized(true);
                return RedirectToAction("LoggedIn", new{id = id});
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
            Checking.IsAuthorized(false);
            return RedirectToAction("Login");
        }

        public ActionResult LoggedIn(int id)
        {
            if (Checking.IsAuthorized())
            {
                Checking.IsAuthorized(false);
                User user;
                using (BloggV1Connection db = new BloggV1Connection())
                {
                    user = db.Users.SingleOrDefault(x => x.UserId == id);
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}