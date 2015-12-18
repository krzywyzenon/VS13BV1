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
                        bloggs = db.Bloggs.Where(x => x.CategoryId == categoryId).ToList();
                        break;

                    case "user":
                        bloggs = db.Bloggs.Where(x => x.UserId == userId).ToList(); //TODO UPdatenac view zeby zawieralo id i stad kurwa mac
                        break;

                    case "title":
                        bloggs = db.Bloggs.Where(x => x.Title.Contains(bloggTitle)).ToList();
                        int f = 2;
                        break;

                    default:
                        bloggs = db.Bloggs.ToList();
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