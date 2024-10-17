using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;
using WooxTravel.Entities;

namespace WooxTravel.Areas.Admin.Controllers
{
    [Authorize]
    public class DestinationController : Controller
    {
        TravelContext travelContext = new TravelContext();
        public ActionResult DestinationList()
        {
            var value = travelContext.Destinations.ToList();
            return View(value);
        }
        public ActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDestination(Destination destination)
        {
            travelContext.Destinations.Add(destination);
            travelContext.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
        public ActionResult DeleteDestination(int id)
        {
            var value = travelContext.Destinations.Find(id);
            travelContext.Destinations.Remove(value);
            travelContext.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
        public ActionResult UpdateDestination(int id)
        {
            var value = travelContext.Destinations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateDestination(Destination destination)
        {
            var value = travelContext.Destinations.Find(destination.DestinationId);
            value.Title = destination.Title;
            value.Description = destination.Description;
            value.City = destination.City;
            value.DayNight = destination.DayNight;
            value.Country = destination.Country;
            value.ImgUrl = destination.ImgUrl;
            value.Price = destination.Price;
            travelContext.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
    }
}