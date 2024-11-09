using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravel.Context;

namespace WooxTravel.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly TravelContext _context = new TravelContext(); // Veri tabanı bağlamı

        public ActionResult Index()
        {
            // 1. Rotalar grafiği için veri (Ülkelere göre varış noktaları sayısı)
            var destinationsData = _context.Destinations.GroupBy(d => d.Country)
                                             .Select(g => new
                                             {
                                                 Country = g.Key,
                                                 Count = g.Count()
                                             }).ToList();

            // 2. Mesajlar grafiği için veri (Okunmuş ve okunmamış mesaj sayısı)
            var messagesData = _context.Messages.GroupBy(m => m.IsRead)
                                                .Select(g => new
                                                {
                                                    Status = g.Key ? "Okundu" : "Okunmadı",
                                                    Count = g.Count()
                                                }).ToList();

            // 3. Kategoriler grafiği için veri (Kategori durumuna göre kategori sayısı)
            var categoriesData = _context.Categories.GroupBy(c => c.CategoryStatus)
                                                    .Select(g => new
                                                    {
                                                        Status = g.Key,
                                                        Count = g.Count()
                                                    }).ToList();

            // 4. Rezervasyonlar grafiği için veri (Günlük rezervasyon sayısı)
            var reservationsData = _context.Reservations.GroupBy(r => r.ReservationDate)
                                                        .Select(g => new
                                                        {
                                                            Date = g.Key,
                                                            Count = g.Count()
                                                        }).ToList();

            // Veriyi View'e gönder
            ViewBag.DestinationsData = destinationsData;
            ViewBag.MessagesData = messagesData;
            ViewBag.CategoriesData = categoriesData;
            ViewBag.ReservationsData = reservationsData;

            return View();
        }
    }
}