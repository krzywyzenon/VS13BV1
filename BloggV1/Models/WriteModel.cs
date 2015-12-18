using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloggV1.Models
{
    public class WriteModel
    {
        public User user { get; set; }
        public IEnumerable<SelectListItem> categories { get; set; }
        public Article article { get; set; }
    }
}