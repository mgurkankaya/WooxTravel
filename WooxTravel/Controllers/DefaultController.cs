using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WooxTravel.Context;
using WooxTravel.Entities;


namespace WooxTravel.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var value = context.Destinations.Take(5).ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialCountry(int page = 1)
        {
            var value = context.Destinations.ToList().ToPagedList(page, 3);
            return PartialView(value);
        }
        public ActionResult DestinationDetail(int id)
        {
            var value = context.Destinations.Find(id);
            return View(value);
        }

        public JsonResult Reservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                context.Reservations.Add(reservation);       // Rezervasyonu veritabanına ekle
                context.SaveChanges();                       // Veritabanında değişiklikleri kaydet

                // Başarı durumunda JSON döndür
                return Json(new { success = true, message = "Rezervasyonunuz başarıyla oluşturuldu." });
            }

            // Hata durumunda JSON yanıt
            return Json(new { success = false, message = "Rezervasyon oluşturulamadı. Lütfen tekrar deneyin." });
        }



        public PartialViewResult PartialCallToAction()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
    }
}