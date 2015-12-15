using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloggV1.Models;

namespace BloggV1.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
        public ActionResult ReadBlogg()
        {
            List<Article> articles;
            using (BloggV1Connection db = new BloggV1Connection())
            {
                articles = db.Articles.ToList();
            }
            return View(articles);
        }


        public ActionResult ReadUserBlogg(int id)
        {
            List<Article> articles = new List<Article>();
            using (BloggV1Connection db = new BloggV1Connection())
            {
                articles = db.Articles.Where(x => x.UserId == id).ToList();
            }
            return View(articles);
        }

        
    }
}