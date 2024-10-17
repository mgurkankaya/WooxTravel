using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    [Authorize]

    public class ProfileController : Controller
    {

       TravelContext travelContext = new TravelContext();
        public ActionResult Index()
        {
            var username = Session["username"];
            var values = travelContext.Admins.Where(x=>x.UserName == username).FirstOrDefault();
            return View(values);
        }
    }
}