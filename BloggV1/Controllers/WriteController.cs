using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloggV1.Models;

namespace BloggV1.Controllers
{
    public class WriteController : Controller
    {
        // GET: Write
        public ActionResult WriteBlogg(int id)
        {
            User user;
            List<Category> categoriesList;

            using (BloggV1Connection db = new BloggV1Connection())
            {
                user = db.Users.SingleOrDefault(u => u.UserId == id);
                categoriesList = db.Categories.Select(x => x).ToList();
            }
            var model = new WriteModel()
            {
                user   = user,
               categories = categoriesList.Select(x=> new SelectListItem()
               {
                   Value = x.CategoryId.ToString(),
                   Text = x.CategoryName
               }),
               article = new Article()
            };
            ViewBag.userId = id;
            return View(model);
        }

        [HttpPost]
        public ActionResult WriteBlogg(WriteModel model)
        {
            using (BloggV1Connection db = new BloggV1Connection())
            {
                db.Articles.Add(model.article);
                db.SaveChanges();
            }

            ViewBag.isLogged = true;
            Checking.IsAuthorized(true);
            int userId = model.article.UserId;

            return RedirectToAction("LoggedIn", "Main", new { id = userId });
            //return RedirectToAction("Login", "Main", model.user);
            //return View(model);
        }
    }
}