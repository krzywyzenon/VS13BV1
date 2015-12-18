using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloggV1.Models;

namespace BloggV1.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        
        public ActionResult SearchByTitle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchByTitle(string title)
        {
            return RedirectToAction("ReadBlogg", "Read", new {bloggTitle = title, searchCriteria = "title"});
        }

        
        public ActionResult SearchByCategory()
        {
            List<Category> categoriesList;

            using (BloggV1Connection db = new BloggV1Connection())
            {
                categoriesList = db.Categories.Select(x => x).ToList();
            }
            var model = new SearchCategoryModel()
            {
                categories = categoriesList.Select(x => new SelectListItem()
                {
                    Value = x.CategoryId.ToString(),
                    Text = x.CategoryName
                })
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchByCategory(int id)
        {

            return RedirectToAction("ReadBlogg", "Read", new {categoryId = id, searchCriteria = "category"});
        }
    }
}