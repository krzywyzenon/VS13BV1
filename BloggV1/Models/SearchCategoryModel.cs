using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloggV1.Models
{
    public class SearchCategoryModel
    {
        public IEnumerable<SelectListItem> categories { get; set; }
        public int Id { get; set; }
    }
}