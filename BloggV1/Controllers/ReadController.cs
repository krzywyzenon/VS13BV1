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
            List<Blogg> bloggs;
            using (BloggV1Connection db = new BloggV1Connection())
            {
                bloggs = db.Bloggs.ToList();
            }
            return View(bloggs);
        }


        public ActionResult ReadUserBlogg(int id)
        {
            List<Blogg> bloggs = new List<Blogg>();
            using (BloggV1Connection db = new BloggV1Connection())
            {
                bloggs = db.Bloggs.Where(x => x.UserId == id).ToList(); //TODO UPdatenac view zeby zawieralo id i stad kurwa mac
            }
            return View(bloggs);
        }

        
    }
}