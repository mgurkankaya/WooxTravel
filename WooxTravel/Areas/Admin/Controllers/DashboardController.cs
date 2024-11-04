using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        TravelContext c = new TravelContext();
        public ActionResult Index()
        {
            var username = Session["username"];
            var email = c.Admins.Where(x => x.UserName == username).Select(x => x.Email).FirstOrDefault();
            ViewBag.resCount = c.Reservations.ToList().Count();
            ViewBag.userCount = c.Admins.ToList().Count();
            ViewBag.catCount = c.Categories.ToList().Count();
            ViewBag.germanTours = c.Destinations.Where(x => x.Country == "Almanya").ToList().Count();
            ViewBag.lessThan = c.Destinations.Where(x => x.DayNight < 5).ToList().Count();
            ViewBag.moreThan = c.Destinations.Where(x => x.DayNight >=5).ToList().Count();
            ViewBag.expensive = c.Destinations.Max(x => x.Price);
            ViewBag.cheap = c.Destinations.Min(x => x.Price);
            ViewBag.complaint = c.Messages.Where(x => x.Subject == "Şikayet").ToList().Count();
            ViewBag.messageCount = c.Messages.Where(x => x.ReceiverMail == email).Count();
            ViewBag.readMessageCount = c.Messages.Where(x => x.ReceiverMail == email && x.IsRead == true).Count();
            ViewBag.sentMessageCount = c.Messages.Where(x => x.SenderMail == email).Count();
            return View();
        }
    }
}