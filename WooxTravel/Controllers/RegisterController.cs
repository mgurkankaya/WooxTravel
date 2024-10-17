using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        TravelContext travelContext = new TravelContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            travelContext.Admins.Add(admin);
            travelContext.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}