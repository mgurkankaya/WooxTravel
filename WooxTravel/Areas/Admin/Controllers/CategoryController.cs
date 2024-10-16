using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        TravelContext context = new TravelContext();
        
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
    }
}