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
        public ActionResult ReadBlogg(int categoryId = -1, int userId = -1, string bloggTitle = "", string searchCriteria = "")
        {
            List<Blogg> bloggs;

            using (BloggV1Connection db = new BloggV1Connection())
            {
                
                switch (searchCriteria)
                {
                    case "category":
                        bloggs = db.Bloggs.Where(x => x.CategoryId == categoryId).OrderByDescending(x=>x.Date).ToList();
                        break;

                    case "user":
                        bloggs = db.Bloggs.Where(x => x.UserId == userId).OrderByDescending(x => x.Date).ToList(); 
                        break;

                    case "title":
                        bloggs = db.Bloggs.Where(x => x.Title.Contains(bloggTitle)).OrderByDescending(x => x.Date).ToList();
                        int f = 2;
                        break;

                    default:
                        bloggs = db.Bloggs.OrderByDescending(x => x.Date).ToList();
                        break;
                }
            }
            return View(bloggs);
        }

        public ActionResult ReadSingleBlogg(int id)
        {
            Blogg article;
            using (BloggV1Connection db = new BloggV1Connection())
            {
                article = db.Bloggs.SingleOrDefault(x => x.ArticleId == id);
            }
            return View(article);
        }

    }
}